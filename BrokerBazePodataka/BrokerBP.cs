using Domen;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Transactions;

namespace BrokerBazePodataka
{
    public class BrokerBP
    {
        private Broker broker;
        public BrokerBP()
        {
            broker = new Broker();
        }

        //Genericke metode
        public void Insert(IEntity entity)
        {
            try
            {
                broker.OpenConnection();
                string upit = $"INSERT INTO {entity.TableName} VALUES ({entity.Values})";
                broker.ExecuteNonQuery(upit);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greska pri dodavanju u tabelu {entity.TableName}: {ex.Message}");
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Update(IEntity entity, string whereUpit)
        {
            try
            {
                broker.OpenConnection();
                string query = $"UPDATE {entity.TableName} SET ... WHERE {whereUpit}";
                broker.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greska pri azuriranju tabele {entity.TableName}: {ex.Message}");
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Delete(IEntity entity, string whereUpit)
        {
            try
            {
                broker.OpenConnection();
                string query = $"DELETE FROM {entity.TableName} WHERE {whereUpit}";
                broker.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greska pri brisanju iz {entity.TableName}: {ex.Message}");
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            List<IEntity> list = null;
            try
            {
                broker.OpenConnection();
                string upit = $"SELECT * FROM {entity.TableName}";
                SqlDataReader reader = broker.ExecuteReader(upit);
                list = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška pri učitavanju iz {entity.TableName}: {ex.Message}");
            }
            finally
            {
                broker.CloseConnection();
            }
            return list;
        }


        //SLUCAJEVI KORISCENJA

        public Stanodavac Login(Stanodavac stanodavac)
        {
            try
            {
                broker.OpenConnection();
                string upit = "SELECT * FROM Stanodavac WHERE Email=@email AND Password=@password";
                var parametri = new Dictionary<string, object>
                {
                    { "@email", stanodavac.Email },
                    { "@password", stanodavac.Password }
                };
                SqlDataReader reader = broker.ExecuteReader(upit, parametri);
                Stanodavac ulogovani = null;
                if (reader.Read())
                {
                    ulogovani = new Stanodavac
                    {
                        IdStanodavac = (int)reader["idStanodavac"],
                        Ime = (string)reader["Ime"],
                        Prezime = (string)reader["Prezime"],
                        BrojTelefona = (string)reader["BrojTelefona"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"],
                    };
                }
                reader.Close();
                return ulogovani;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void KreirajZakupac(Zakupac zakupac)
        {
            try
            {
                broker.OpenConnection();
                string upitProvera = "SELECT COUNT(*) FROM Zakupac WHERE Email=@email OR BrojTelefona=@brojtelefona";
                var parametri = new Dictionary<string, object>
                {
                    { "@email", zakupac.Email },
                    { "@brojtelefona", zakupac.BrojTelefona }
                };
                object result = broker.ExecuteScalar(upitProvera, parametri);
                int count = Convert.ToInt32(result);
                if (count > 0)
                {
                    throw new Exception("Zakupac sa unetim email-om ili brojem telefona vec postoji.");
                }
                broker.CloseConnection();
                Insert(zakupac);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Zakupac> PretraziZakupac(string email, string ime, string prezime, int? mestoId)
        {
            try
            {
                broker.OpenConnection();
                List<Zakupac> zakupci = new List<Zakupac>();

                string upit = @"SELECT * FROM Zakupac WHERE 1=1";
                var parametri = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(email))
                {
                    upit += " AND Email LIKE @email";
                    parametri.Add("@email", "%" + email + "%");
                }
                if (!string.IsNullOrEmpty(ime))
                {
                    upit += " AND Ime LIKE @ime";
                    parametri.Add("@ime", "%" + ime + "%");
                }
                if (!string.IsNullOrEmpty(prezime))
                {
                    upit += " AND Prezime LIKE @prezime";
                    parametri.Add("@prezime", "%" + prezime + "%");
                }
                if (mestoId.HasValue)
                {
                    upit += " AND idMesto = @idMesto";
                    parametri.Add("@idMesto", mestoId.Value);
                }
                SqlDataReader reader = broker.ExecuteReader(upit, parametri);
                while (reader.Read())
                {
                    Zakupac zakupac = new Zakupac
                    {
                        IdZakupac = (int)reader["idZakupac"],
                        Ime = (string)reader["Ime"],
                        Prezime = (string)reader["Prezime"],
                        BrojTelefona = (string)reader["BrojTelefona"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"],
                        IdMesto = (int)reader["idMesto"]
                    };
                    zakupci.Add(zakupac);
                }
                reader.Close();
                return zakupci;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void PromeniZakupac(Zakupac zakupac)
        {
            try
            {
                broker.OpenConnection();
                string upitProvera = "SELECT COUNT(*) FROM Zakupac WHERE (Email=@email OR BrojTelefona=@brojtelefona) AND idZakupac<>@idZakupac";
                var parametri = new Dictionary<string, object>()
                {
                    {"@email", zakupac.Email},
                    {"@brojtelefona", zakupac.BrojTelefona },
                    {"@idZakupac", zakupac.IdZakupac }
                };
                object result = broker.ExecuteScalar(upitProvera, parametri);
                int count = Convert.ToInt32(result);
                if (count > 0)
                {
                    throw new Exception("Zakupac sa unetim email-om ili brojem telefona već postoji.");
                }
                string upit = "UPDATE Zakupac SET Ime=@ime, Prezime=@prezime, BrojTelefona=@brojTelefona, Email=@email, Password=@password, idMesto=@idmesto WHERE idZakupac=@idZakupac";
                var parametriUpit = new Dictionary<string, object>()
                {
                    {"@ime", zakupac.Ime},
                    {"@prezime", zakupac.Prezime },
                    {"@brojTelefona", zakupac.BrojTelefona },
                    {"@email", zakupac.Email },
                    {"@password", zakupac.Password },
                    {"@idmesto", zakupac.IdMesto},
                    {"@idZakupac", zakupac.IdZakupac }
                };
                int rows = broker.ExecuteNonQuery(upit, parametriUpit);
                if (rows == 0)
                {
                    throw new Exception("Sistem ne moze da zapamti zakupca");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.CloseConnection(); }
        }


        public void ObrisiZakupac(int zakupacId)
        {
            try
            {
                broker.OpenConnection();
                string upitProvera = $"SELECT COUNT(*) FROM Ugovor WHERE idZakupac=@zakupacId";
                var parametar = new Dictionary<string, object>() { { "@zakupacId", zakupacId } };
                object result = broker.ExecuteScalar(upitProvera, parametar);
                int count = Convert.ToInt32(result);
                if (count > 0)
                {
                    throw new Exception("Sistem ne moze da obrise zakupca, jer postoji ugovor povezan s njim.");
                }

                string upit = $"DELETE FROM Zakupac WHERE idZakupac=@zakupacId";
                int rows = broker.ExecuteNonQuery(upit, parametar);
                if (rows == 0)
                {
                    throw new Exception("Sistem ne moze da obrise zakupca");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }


        public void KreirajUgovor(Ugovor ugovor)
        {
            try
            {
                broker.OpenConnection();

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su ON su.idUgovor = u.idUgovor WHERE su.idStan = @idStan AND (u.DatumDo >= @datumOd AND u.DatumOd <= @datumDo)";
                    var parametriProvera = new Dictionary<string, object> {
                        {"@idStan", stavka.IdStan },
                        {"@datumOd", ugovor.DatumOd },
                        {"@datumDo", ugovor.DatumDo },
                    };
                    int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
                    if (count > 0)
                    {
                        throw new Exception($"Sistem ne moze da zapamti ugovor, jer postoji ugovor za taj stan u navedenom periodu.");
                    }
                }

                broker.BeginTransaction();

                string upitUgovor = "INSERT INTO Ugovor (DatumOd, DatumDo, idStanodavac, idZakupac) OUTPUT inserted.idUgovor VALUES (@datumOd, @datumDo, @idStanodavac, @idZakupac)";
                var parametriUgovor = new Dictionary<string, object>
                {
                    { "@datumOd", ugovor.DatumOd },
                    { "@datumDo", ugovor.DatumDo },
                    { "@idStanodavac", ugovor.IdStanodavac },
                    { "@idZakupac", ugovor.IdZakupac }
                };
                int idUgovor = Convert.ToInt32(broker.ExecuteScalar(upitUgovor, parametriUgovor));
                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    stavka.IdUgovora = idUgovor;
                    string queryStavka = $"INSERT INTO StavkaUgovora VALUES ({stavka.Values})";
                    broker.ExecuteNonQuery(queryStavka);
                }
                broker.Commit();

            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Ugovor> PretraziUgovor(DateTime? datumOd, DateTime? datumDo, int? idZakupac, int? idStanodavac)
        {
            try
            {
                broker.OpenConnection();
                List<Ugovor> ugovori = new List<Ugovor>();
                string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                    "(" +
                    "SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor" +
                    ") AS UkupanIznos " +
                    "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac " +
                    "WHERE 1=1";
                var parametri = new Dictionary<string, object>();
                if (datumOd.HasValue)
                {
                    upit += " AND u.DatumOd >= @datumOd";
                    parametri.Add("@datumOd", datumOd.Value.Date);
                }
                if (datumDo.HasValue)
                {
                    upit += " AND u.DatumDo <= @datumDo";
                    parametri.Add("@datumDo", datumDo.Value.Date);
                }

                if (idZakupac.HasValue)
                {
                    upit += " AND u.idZakupac = @idZakupac";
                    parametri.Add("@idZakupac", idZakupac.Value);
                }
                if (idStanodavac.HasValue)
                {
                    upit += " AND u.idStanodavac = @idStanodavac";
                    parametri.Add("@idStanodavac", idStanodavac.Value);
                }
                upit += " ORDER BY u.DatumOd DESC";

                SqlDataReader reader = broker.ExecuteReader(upit, parametri);
                while (reader.Read())
                {
                    Ugovor ugovor = new Ugovor
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
                    ugovori.Add(ugovor);
                }
                reader.Close();
                return ugovori;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }


        public void PromeniUgovor(Ugovor ugovor)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su on u.idUgovor=su.idUgovor WHERE su.idStan=@idStan AND su.idUgovor<>@idUgovor" +
                        " AND (u.DatumDo>=@datumOd AND u.DatumOd<=@datumDo)";
                    var parametriProvera = new Dictionary<string, object>
                    {
                        { "@idStan", stavka.IdStan },
                        { "@idUgovor", ugovor.IdUgovor },
                        { "@datumOd", ugovor.DatumOd.Date },
                        { "@datumDo", ugovor.DatumDo.Date }
                    };
                    int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
                    if (count > 0)
                    {
                        throw new Exception("Sistem ne moze da zapamti ugovor, jer za taj stan postoji ugovor u navedenom periodu.");
                    }
                }

                string upitUgovor = "UPDATE Ugovor SET DatumOd=@datumOd, DatumDo=@datumDo, idStanodavac=@idStanodavac, idZakupac=@idZakupac WHERE idUgovor=@idUgovor";
                var parametriUgovor = new Dictionary<string, object>
                {
                    { "@datumOd", ugovor.DatumOd.Date },
                    { "@datumDo", ugovor.DatumDo.Date },
                    { "@idStanodavac", ugovor.IdStanodavac },
                    { "@idZakupac", ugovor.IdZakupac },
                    { "@idUgovor", ugovor.IdUgovor }
                };
                int rows = broker.ExecuteNonQuery(upitUgovor, parametriUgovor);
                if (rows == 0)
                {
                    throw new Exception("Sistem ne moze da zapamti ugovor");
                }


                string upitBrisanjeStavki = "DELETE FROM StavkaUgovora WHERE idUgovor=@idUgovor";
                broker.ExecuteNonQuery(upitBrisanjeStavki, new Dictionary<string, object> { { "@idUgovor", ugovor.IdUgovor } });

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    stavka.IdUgovora = ugovor.IdUgovor;
                    string queryStavka = $"INSERT INTO StavkaUgovora VALUES ({stavka.Values})";
                    broker.ExecuteNonQuery(queryStavka);
                }
                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void UbaciTerminIznajmljivanja(TerminIznajmljivanja termin, int idStanodavac, string opisStatusa)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                string upitProvera = "SELECT COUNT(*) FROM TerminIznajmljivanja t JOIN Status s on t.idTerminIz=s.idTerminIz WHERE s.idStanodavac=@idStanodavac AND " +
                    "t.DatumDo >= @datumOd AND t.DatumOd <= @datumDo";
                var parametriProvera = new Dictionary<string, object>()
                {
                    { "@idStanodavac", idStanodavac },
                    { "@datumOd", termin.DatumOd.Date },
                    { "@datumDo", termin.DatumDo.Date }
                };
                int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
                if (count > 0)
                {
                    throw new Exception("Sistem ne moze da zapamti termin iznajmljivanja, jer postoji termin u navedenom periodu.");
                }

                string upitTermin = "INSERT INTO TerminIznajmljivanja (DatumOd, DatumDo) OUTPUT inserted.idTerminIz VALUES (@datumOd,@datumDo)";
                var parametriTermin = new Dictionary<string, object>()
                {
                    { "@datumOd", termin.DatumOd.Date },
                    { "@datumDo", termin.DatumDo.Date }
                };
                int idTerminIz = Convert.ToInt32(broker.ExecuteScalar(upitTermin, parametriTermin));


                string upitStatus = "INSERT INTO Status (idTerminIz, idStanodavac, OpisStatusa) VALUES (@idTerminIz, @idStanodavac, @opisStatusa)";
                var parametriStatus = new Dictionary<string, object>()
                {
                    { "@idTerminIz", idTerminIz },
                    { "@idStanodavac", idStanodavac },
                    { "@opisStatusa", opisStatusa }
                };
                broker.ExecuteNonQuery(upitStatus, parametriStatus);

                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        //Pomocne metode

        public Ugovor VratiUgovorSaStavkama(int idUgovor)
        {
            try
            {
                broker.OpenConnection();

                Ugovor ugovor = null;
                string upitOsnovni = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'ZakupacImePrezime', " +
                     "s.Ime + ' ' + s.Prezime AS 'StanodavacImePrezime' " +
                     "FROM Ugovor u JOIN Zakupac z ON u.idZakupac = z.idZakupac " +
                     "JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac " +
                     $"WHERE u.idUgovor = @idUgovor";

                SqlDataReader reader = broker.ExecuteReader(upitOsnovni, new Dictionary<string, object> { { "@idUgovor", idUgovor } });
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
                reader.Close();

                if (ugovor == null)
                {
                    throw new Exception("Ugovor nije pronadjen");
                }
                string upitStavka = $"SELECT su.*, st.Adresa, st.Povrsina, st.TipStana,st.BrojSoba FROM StavkaUgovora su JOIN Stan st on su.idStan=st.idStan WHERE su.idUgovor=@idUgovor ORDER BY su.rb";

                SqlDataReader reader2 = broker.ExecuteReader(upitStavka, new Dictionary<string, object> { { "@idUgovor", idUgovor } });
                while (reader2.Read())
                {
                    StavkaUgovora stavka = new StavkaUgovora
                    {
                        IdStan = (int)reader2["idStan"],
                        IdUgovora = (int)reader2["idUgovor"],
                        Iznos = Convert.ToDecimal(reader2["Iznos"]),
                        Rb = (int)reader2["rb"],
                        Stan = new Stan
                        {
                            Adresa = (string)reader2["Adresa"],
                            BrojSoba = (double)reader2["BrojSoba"],
                            IdStan = (int)reader2["idStan"],
                            Povrsina = (int)reader2["Povrsina"],
                            TipStana = (TipStana)Convert.ToInt32(reader2["TipStana"])
                        }
                    };
                    ugovor.StavkeUgovora.Add(stavka);
                }
                reader2.Close();
                return ugovor;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju ugovora sa stavkama: " + ex.Message);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Ugovor> VratiSveUgovore()
        {
            try
            {
                broker.OpenConnection();
                string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                "(" +
                "SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor" +
                ") AS UkupanIznos " +
                "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac";
                List<Ugovor> ugovori = new List<Ugovor>();
                SqlDataReader reader = broker.ExecuteReader(upit);
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
                return ugovori;
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.CloseConnection(); }
        }

        public List<Stan> VratiListuStanova()
        {
            List<IEntity> entities = GetAll(new Stan());
            return entities.Cast<Stan>().ToList();
        }
        public List<Mesto> VratiSvaMesta()
        {
            List<IEntity> entities = GetAll(new Mesto());
            return entities.Cast<Mesto>().ToList();
        }
        public List<Zakupac> VratiSveZakupce()
        {
            List<IEntity> entities = GetAll(new Zakupac());
            return entities.Cast<Zakupac>().ToList();
        }
    }
}