using Domen;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace BrokerBazePodataka
{
    public class BrokerBP
    {
        private SqlConnection connection;
        public void Connect()
        {
            try
            {
                connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IznajmljivanjeStanova;Integrated Security=True");
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void Disconnect()
        {
            connection?.Close();
        }
        /////SLUCAJEVI KORISCENJA////////
        public Stanodavac Login(string email, string password)
        {
            try
            {
                Connect();
                string upit = "SELECT * FROM Stanodavac WHERE Email=@email AND Password=@password";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Stanodavac s = new Stanodavac
                            {
                                IdStanodavac = (int)reader["idStanodavac"],
                                Ime = (string)reader["Ime"],
                                Prezime = (string)reader["Prezime"],
                                BrojTelefona = (string)reader["BrojTelefona"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"],
                            };
                            return s;
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public void KreirajZakupac(Zakupac zakupac)
        {
            try
            {
                Connect();
                string upitProvera = "SELECT COUNT(*) FROM Zakupac WHERE Email=@email OR BrojTelefona=@brojtelefona";
                using (SqlCommand cmdProvera = new SqlCommand(upitProvera, connection))
                {
                    cmdProvera.Parameters.AddWithValue("@email", zakupac.Email);
                    cmdProvera.Parameters.AddWithValue("@brojtelefona", zakupac.BrojTelefona);
                    int count = (int)cmdProvera.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Zakupac sa unetim email-om ili brojem telefona vec postoji.");
                    }
                }
                string upit = "INSERT INTO Zakupac (Ime, Prezime, BrojTelefona, Email, Password,idMesto) VALUES (@ime, @prezime, @brojTelefona, @email, @password,@idmesto)";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    cmd.Parameters.AddWithValue("@ime", zakupac.Ime);
                    cmd.Parameters.AddWithValue("@prezime", zakupac.Prezime);
                    cmd.Parameters.AddWithValue("@brojTelefona", zakupac.BrojTelefona);
                    cmd.Parameters.AddWithValue("@email", zakupac.Email);
                    cmd.Parameters.AddWithValue("@password", zakupac.Password);
                    cmd.Parameters.AddWithValue("@idmesto", zakupac.IdMesto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Zakupac> PretraziZakupac(string email, string ime, string prezime, int? mestoId)
        {
            try
            {
                Connect();
                List<Zakupac> zakupci = new List<Zakupac>();
                string upit = "SELECT * FROM Zakupac WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(email))
                {
                    upit += " AND Email LIKE @email";
                }
                if (!string.IsNullOrWhiteSpace(ime))
                {
                    upit += " AND Ime LIKE @ime";
                }
                if (!string.IsNullOrWhiteSpace(prezime))
                {
                    upit += " AND Prezime LIKE @prezime";
                }
                if (mestoId.HasValue)
                {
                    upit += " AND idMesto = @idmesto";
                }
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        cmd.Parameters.AddWithValue("@email", "%" + email + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(ime))
                    {
                        cmd.Parameters.AddWithValue("@ime", "%" + ime + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(prezime))
                    {
                        cmd.Parameters.AddWithValue("@prezime", "%" + prezime + "%");
                    }
                    if (mestoId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idmesto", mestoId);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Zakupac z = new Zakupac
                            {
                                IdZakupac = (int)reader["idZakupac"],
                                Ime = (string)reader["Ime"],
                                Prezime = (string)reader["Prezime"],
                                BrojTelefona = (string)reader["BrojTelefona"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"],
                                IdMesto = (int)reader["idMesto"]
                            };
                            zakupci.Add(z);
                        }
                    }
                    return zakupci;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public void PromeniZakupac(Zakupac zakupac)
        {
            try
            {
                Connect();
                string upitProvera = "SELECT COUNT(*) FROM Zakupac WHERE (Email=@email OR BrojTelefona=@brojtelefona) AND idZakupac<>@idZakupac";
                using (SqlCommand cmdProvera = new SqlCommand(upitProvera, connection))
                {
                    cmdProvera.Parameters.AddWithValue("@email", zakupac.Email);
                    cmdProvera.Parameters.AddWithValue("@brojtelefona", zakupac.BrojTelefona);
                    cmdProvera.Parameters.AddWithValue("@idZakupac", zakupac.IdZakupac);
                    int count = (int)cmdProvera.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Zakupac sa unetim email-om ili brojem telefona vec postoji.");
                    }
                }
                string upit = "UPDATE Zakupac SET Ime=@ime, Prezime=@prezime, BrojTelefona=@brojTelefona, Email=@email, Password=@password, idMesto=@idmesto WHERE idZakupac=@idZakupac";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    cmd.Parameters.AddWithValue("@ime", zakupac.Ime);
                    cmd.Parameters.AddWithValue("@prezime", zakupac.Prezime);
                    cmd.Parameters.AddWithValue("@brojTelefona", zakupac.BrojTelefona);
                    cmd.Parameters.AddWithValue("@email", zakupac.Email);
                    cmd.Parameters.AddWithValue("@password", zakupac.Password);
                    cmd.Parameters.AddWithValue("@idmesto", zakupac.IdMesto);
                    cmd.Parameters.AddWithValue("@idZakupac", zakupac.IdZakupac);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("Sistem ne moze da zapamti zakupca");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }

        }
        public void ObrisiZakupac(int idZakupac)
        {
            try
            {
                Connect();
                string upitProvera = "SELECT COUNT(*) FROM Ugovor WHERE idZakupac=@idZakupac";
                using (SqlCommand cmd = new SqlCommand(upitProvera, connection))
                {
                    cmd.Parameters.AddWithValue("@idZakupac", idZakupac);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Sistem ne moze da obrise zakupca, jer postoji ugovor povezan s njim.");
                    }
                }
                string upit = "DELETE FROM Zakupac WHERE idZakupac=@idZakupac";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    cmd.Parameters.AddWithValue("@idZakupac", idZakupac);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("Sistem ne moze da obrise zakupca");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        public void KreirajUgovor(Ugovor ugovor)
        {
            SqlTransaction? transaction = null;
            try
            {
                Connect();

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su ON su.idUgovor = u.idUgovor WHERE su.idStan = @idStan AND (u.DatumDo >= @datumOd AND u.DatumOd <= @datumDo)";
                    using (SqlCommand cmdProvera = new SqlCommand(upitProvera, connection))
                    {
                        cmdProvera.Parameters.AddWithValue("@idStan", stavka.IdStan);
                        cmdProvera.Parameters.AddWithValue("@datumOd", ugovor.DatumOd);
                        cmdProvera.Parameters.AddWithValue("@datumDo", ugovor.DatumDo);
                        int count = (int)cmdProvera.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new Exception($"Sistem ne moze da zapamti ugovor, jer postoji ugovor za taj stan u navedenom periodu.");
                        }
                    }
                }
                using (transaction = connection.BeginTransaction())
                {
                    string upitUgovor = "INSERT INTO Ugovor (DatumOd, DatumDo, idStanodavac, idZakupac) OUTPUT inserted.idUgovor VALUES (@datumOd, @datumDo, @idStanodavac, @idZakupac)";
                    int idUgovor;
                    using (SqlCommand cmd = new SqlCommand(upitUgovor, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@datumOd", ugovor.DatumOd);
                        cmd.Parameters.AddWithValue("@datumDo", ugovor.DatumDo);
                        cmd.Parameters.AddWithValue("@idStanodavac", ugovor.IdStanodavac);
                        cmd.Parameters.AddWithValue("@idZakupac", ugovor.IdZakupac);
                        idUgovor = (int)cmd.ExecuteScalar();
                    }
                    string upitStavka = "INSERT INTO StavkaUgovora (idUgovor,rb,idStan, Iznos) VALUES (@idUgovor,@rb,@idStan, @iznos)";
                    foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                    {
                        using (SqlCommand cmd = new SqlCommand(upitStavka, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idUgovor", idUgovor);
                            cmd.Parameters.AddWithValue("@rb", stavka.Rb);
                            cmd.Parameters.AddWithValue("@idStan", stavka.IdStan);
                            cmd.Parameters.AddWithValue("@iznos", stavka.Iznos);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Ugovor> PretraziUgovor(DateTime? datumOd, DateTime? datumDo, int? idZakupac, int? idStanodavac)
        {
            try
            {
                Connect();
                string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                    "(" +
                    "SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor" +
                    ") AS UkupanIznos " +
                    "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac " +
                    "WHERE 1=1";
                if (datumOd.HasValue)
                {
                    upit += " AND u.DatumOd >= @datumOd";
                }
                if (datumDo.HasValue)
                {
                    upit += " AND u.DatumDo <= @datumDo";
                }

                if (idZakupac.HasValue)
                {
                    upit += " AND u.idZakupac = @idZakupac";
                }
                if (idStanodavac.HasValue)
                {
                    upit += " AND u.idStanodavac = @idStanodavac";
                }
                upit += " ORDER BY u.DatumOd DESC";
                List<Ugovor> ugovori = new List<Ugovor>();
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    if (datumOd.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@datumOd", datumOd.Value.Date);
                    }
                    if (datumDo.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@datumDo", datumDo.Value.Date);
                    }
                    if (idZakupac.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idZakupac", idZakupac.Value);
                    }
                    if (idStanodavac.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idStanodavac", idStanodavac.Value);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ugovor u = new Ugovor
                            {
                                IdUgovor = (int)reader["idUgovor"],
                                DatumOd = (DateTime)reader["DatumOd"],
                                DatumDo = (DateTime)reader["DatumDo"],
                                IdStanodavac = (int)reader["idStanodavac"],
                                IdZakupac = (int)reader["idZakupac"],
                                //Za prikaz
                                StanodavacImePrezime = (string)reader["Stanodavac"],
                                ZakupacImePrezime = (string)reader["Zakupac"],
                                UkupanIznos = Convert.ToDecimal(reader["UkupanIznos"])
                            };
                            ugovori.Add(u);
                        }
                    }
                }
                return ugovori;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public void PromeniUgovor(Ugovor ugovor)
        {
            SqlTransaction? transaction = null;
            try
            {
                Connect();
                using (transaction = connection.BeginTransaction())
                {

                    foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                    {
                        string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su on u.idUgovor=su.idUgovor WHERE su.idStan=@idStan AND su.idUgovor<>@idUgovor" +
                            " AND (u.DatumDo>=@datumOd AND u.DatumOd<=@datumDo)";
                        using (SqlCommand cmdProvera = new SqlCommand(upitProvera, connection, transaction))
                        {
                            cmdProvera.Parameters.AddWithValue("@idStan", stavka.IdStan);
                            cmdProvera.Parameters.AddWithValue("@idUgovor", ugovor.IdUgovor);
                            cmdProvera.Parameters.AddWithValue("@datumOd", ugovor.DatumOd.Date);
                            cmdProvera.Parameters.AddWithValue("@datumDo", ugovor.DatumDo.Date);
                            int count = (int)cmdProvera.ExecuteScalar();
                            if (count > 0)
                            {
                                throw new Exception("Sistem ne moze da zapamti ugovor, jer za taj stan postoji ugovor u navedenom periodu.");
                            }
                        }
                    }

                    string upitUgovor = "UPDATE Ugovor SET DatumOd=@datumOd, DatumDo=@datumDo, idStanodavac=@idStanodavac, idZakupac=@idZakupac WHERE idUgovor=@idUgovor";
                    using (SqlCommand cmd = new SqlCommand(upitUgovor, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@datumOd", ugovor.DatumOd.Date);
                        cmd.Parameters.AddWithValue("@datumDo", ugovor.DatumDo.Date);
                        cmd.Parameters.AddWithValue("@idStanodavac", ugovor.IdStanodavac);
                        cmd.Parameters.AddWithValue("@idZakupac", ugovor.IdZakupac);
                        cmd.Parameters.AddWithValue("@idUgovor", ugovor.IdUgovor);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            throw new Exception("Sistem ne moze da zapamti ugovor");
                        }
                    }

                    string upitBrisanjeStavki = "DELETE FROM StavkaUgovora WHERE idUgovor=@idUgovor";
                    using (SqlCommand cmd = new SqlCommand(upitBrisanjeStavki, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idUgovor", ugovor.IdUgovor);
                        cmd.ExecuteNonQuery();
                    }

                    string upitStavka = "INSERT INTO StavkaUgovora (idUgovor,rb,idStan, Iznos) VALUES (@idUgovor,@rb,@idStan, @iznos)";
                    using (SqlCommand cmd = new SqlCommand(upitStavka, connection, transaction))
                    {
                        foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@idUgovor", ugovor.IdUgovor);
                            cmd.Parameters.AddWithValue("@rb", stavka.Rb);
                            cmd.Parameters.AddWithValue("@idStan", stavka.IdStan);
                            cmd.Parameters.AddWithValue("@iznos", stavka.Iznos);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }

            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        public void UbaciTerminIznajmljivnja(TerminIznajmljivanja termin, int stanodavacId, string opisStatusa)
        {
            SqlTransaction? transaction = null;
            try
            {
                Connect();
                string upitProvera = "SELECT COUNT(*) FROM TerminIznajmljivanja t JOIN Status s on t.idTerminIz=s.idTerminIz WHERE s.idStanodavac=@idStanodavac AND " +
                    "t.DatumDo >= @datumOd AND t.DatumOd <= @datumDo";
                using (transaction = connection.BeginTransaction())
                {
                    using (SqlCommand cmdProvera = new SqlCommand(upitProvera, connection, transaction))
                    {
                        cmdProvera.Parameters.AddWithValue("@idStanodavac", stanodavacId);
                        cmdProvera.Parameters.AddWithValue("@datumOd", termin.DatumOd.Date);
                        cmdProvera.Parameters.AddWithValue("@datumDo", termin.DatumDo.Date);
                        int count = (int)cmdProvera.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new Exception("Sistem ne moze da zapamti termin iznajmljivanja, jer postoji termin u navedenom periodu.");
                        }
                    }
                    string upitTermin = "INSERT INTO TerminIznajmljivanja (DatumOd, DatumDo) OUTPUT inserted.idTerminIz VALUES (@datumOd,@datumDo)";
                    int idTerminIz;
                    using (SqlCommand cmd = new SqlCommand(upitTermin, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@datumOd", termin.DatumOd.Date);
                        cmd.Parameters.AddWithValue("@datumDo", termin.DatumDo.Date);
                        idTerminIz = (int)cmd.ExecuteScalar();
                    }
                    string upitStatus = "INSERT INTO Status (idTerminIz, idStanodavac, OpisStatusa) VALUES (@idTerminIz, @idStanodavac, @opisStatusa)";
                    using (SqlCommand cmd = new SqlCommand(upitStatus, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idTerminIz", idTerminIz);
                        cmd.Parameters.AddWithValue("@idStanodavac", stanodavacId);
                        cmd.Parameters.AddWithValue("@opisStatusa", opisStatusa);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        ////////POMOCNE METODE////////
        public Ugovor VratiUgovorSaStavkama(int idUgovor)
        {
            try
            {
                Connect();
                string upitOsnovni = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'ZakupacImePrezime', " +
                     "s.Ime + ' ' + s.Prezime AS 'StanodavacImePrezime' " +
                     "FROM Ugovor u JOIN Zakupac z ON u.idZakupac = z.idZakupac " +
                     "JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac " +
                     "WHERE u.idUgovor = @idUgovor";
                Ugovor ugovor = null;
                using (SqlCommand cmd = new SqlCommand(upitOsnovni, connection))
                {
                    cmd.Parameters.AddWithValue("@idUgovor", idUgovor);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ugovor = new Ugovor
                            {
                                IdUgovor = (int)reader["idUgovor"],
                                DatumOd = (DateTime)reader["DatumOd"],
                                DatumDo = (DateTime)reader["DatumDo"],
                                IdStanodavac = (int)reader["idStanodavac"],
                                IdZakupac = (int)reader["idZakupac"],
                                StanodavacImePrezime = (string)reader["StanodavacImePrezime"],
                                ZakupacImePrezime = (string)reader["ZakupacImePrezime"],
                            };
                        }
                    }
                }
                if (ugovor == null)
                {
                    throw new Exception("Ugovor nije pronadjen");
                }
                string upitStavka = "SELECT su.*, st.Adresa, st.Povrsina, st.TipStana,st.BrojSoba FROM StavkaUgovora su JOIN Stan st on su.idStan=st.idStan WHERE su.idUgovor=@idUgovor ORDER BY su.rb";
                using (SqlCommand cmd = new SqlCommand(upitStavka, connection))
                {
                    cmd.Parameters.AddWithValue("@idUgovor", idUgovor);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StavkaUgovora stavka = new StavkaUgovora
                            {
                                IdStan = (int)reader["idStan"],
                                IdUgovora = (int)reader["idUgovor"],
                                Iznos = Convert.ToDecimal(reader["Iznos"]),
                                Rb = (int)reader["rb"],
                                Stan = new Stan
                                {
                                    Adresa = (string)reader["Adresa"],
                                    BrojSoba = (double)reader["BrojSoba"],
                                    IdStan = (int)reader["idStan"],
                                    Povrsina = (int)reader["Povrsina"],
                                    TipStana = (TipStana)Convert.ToInt32(reader["TipStana"])
                                }
                            };
                            ugovor.StavkeUgovora.Add(stavka);
                        }
                    }
                }
                return ugovor;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Ugovor> VratiSveUgovore()
        {
            try
            {
                Connect();
                string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                    "(" +
                    "SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor" +
                    ") AS UkupanIznos " +
                    "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac";
                List<Ugovor> ugovori = new List<Ugovor>();
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ugovor u = new Ugovor
                            {
                                IdUgovor = (int)reader["idUgovor"],
                                DatumOd = (DateTime)reader["DatumOd"],
                                DatumDo = (DateTime)reader["DatumDo"],
                                IdStanodavac = (int)reader["idStanodavac"],
                                IdZakupac = (int)reader["idZakupac"],
                                //Za prikaz
                                StanodavacImePrezime = (string)reader["Stanodavac"],
                                ZakupacImePrezime = (string)reader["Zakupac"],
                                UkupanIznos = Convert.ToDecimal(reader["UkupanIznos"])
                            };
                            ugovori.Add(u);
                        }
                    }
                }
                return ugovori;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Stan> VratiListuStanova()
        {
            try
            {
                Connect();
                List<Stan> stanovi = new List<Stan>();
                string upit = "SELECT * FROM Stan ORDER BY Adresa";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stan s = new Stan
                            {
                                IdStan = (int)reader["idStan"],
                                Adresa = (string)reader["Adresa"],
                                Povrsina = (int)reader["Povrsina"],
                                TipStana = (TipStana)Convert.ToInt32(reader["TipStana"]),
                                BrojSoba = (double)reader["BrojSoba"]
                            };
                            stanovi.Add(s);
                        }
                    }
                }
                return stanovi;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Mesto> VratiSvaMesta()
        {
            try
            {
                Connect();
                List<Mesto> mesta = new List<Mesto>();
                string upit = "SELECT * FROM Mesto ORDER BY Naziv";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mesto m = new Mesto
                            {
                                IdMesto = (int)reader["idMesto"],
                                Naziv = (string)reader["Naziv"],
                            };
                            mesta.Add(m);
                        }
                        return mesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public List<Zakupac> VratiSveZakupce()
        {
            try
            {
                Connect();
                List<Zakupac> zakupci = new List<Zakupac>();
                string upit = "SELECT * FROM Zakupac ORDER BY Ime, Prezime";
                using (SqlCommand cmd = new SqlCommand(upit, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Zakupac z = new Zakupac
                            {
                                IdZakupac = (int)reader["idZakupac"],
                                Ime = (string)reader["Ime"],
                                Prezime = (string)reader["Prezime"],
                                BrojTelefona = (string)reader["BrojTelefona"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"],
                                IdMesto = (int)reader["idMesto"]
                            };
                            zakupci.Add(z);
                        }
                        return zakupci;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////
    }
}
