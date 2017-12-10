using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Carsharing
{
    static class Database
    {
        internal static void InsertLocation(string postcode, string city, string street)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO location (postcode, city, street) VALUES (@postcode, @city, @street)", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("postcode", postcode);
                    mySqlCommand.Parameters.AddWithValue("city", city);
                    mySqlCommand.Parameters.AddWithValue("street", street);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        internal static void InsertCar(string name, string make, int power, int seats, int trunksize, string carClass, string gearbox, string fuel, bool coupling, int location_id)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO car (name, make, power, seats, trunksize, class, gearbox, fuel, coupling, location_id) "
                        + "VALUES (@name, @make, @power, @seats, @trunksize, @class, @gearbox, @fuel, @coupling, @location_id)", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("name", name);
                    mySqlCommand.Parameters.AddWithValue("make", make);
                    mySqlCommand.Parameters.AddWithValue("power", power);
                    mySqlCommand.Parameters.AddWithValue("seats", seats);
                    mySqlCommand.Parameters.AddWithValue("trunksize", trunksize);
                    mySqlCommand.Parameters.AddWithValue("class", carClass);
                    mySqlCommand.Parameters.AddWithValue("gearbox", gearbox);
                    mySqlCommand.Parameters.AddWithValue("fuel", fuel);
                    mySqlCommand.Parameters.AddWithValue("coupling", coupling);
                    mySqlCommand.Parameters.AddWithValue("location_id", location_id);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        internal static void InsertUser (string username, string password, string email, string firstname, string lastname, string birthday, string iban, bool admin)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO user (username, password, email, firstname, lastname, birthday, iban, `admin`) "
                        + "VALUES (@username, @password, @email, @firstname, @lastname, @birthday, @iban, @admin)", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("username", username);
                    mySqlCommand.Parameters.AddWithValue("password", password);
                    mySqlCommand.Parameters.AddWithValue("email", email);
                    mySqlCommand.Parameters.AddWithValue("firstname", firstname);
                    mySqlCommand.Parameters.AddWithValue("lastname", lastname);
                    mySqlCommand.Parameters.AddWithValue("birthday", birthday);
                    mySqlCommand.Parameters.AddWithValue("iban", iban);
                    mySqlCommand.Parameters.AddWithValue("admin", admin);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        internal static bool CheckUser(string username, string password)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT COUNT(*) FROM user WHERE username = @username AND password = @password GROUP BY username", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("username", username);
                    mySqlCommand.Parameters.AddWithValue("password", password);
                    mySqlCommand.Prepare();
                    if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            return false;
        }

        internal static bool CheckUser(string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT COUNT(*) FROM user WHERE username = @username GROUP BY username", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("username", username);
                    mySqlCommand.Prepare();
                    if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            return false;
        }

        internal static bool CheckAdmin(string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT `admin` FROM user WHERE username = @username", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("username", username);
                    mySqlCommand.Prepare();
                    return (bool)mySqlCommand.ExecuteScalar();
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        internal static LocationModel GetLocation(int id, MySqlConnection mySqlConnection)
        {
            LocationModel locationModel = new LocationModel();
            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM location WHERE id = @id", mySqlConnection))
            {
                mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                mySqlDataAdapter.SelectCommand.Prepare();
                mySqlDataAdapter.Fill(dataTable);
                locationModel = new LocationModel()
                {
                    Id = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]),
                    Postcode = dataTable.Rows[0].ItemArray[1].ToString(),
                    City = dataTable.Rows[0].ItemArray[2].ToString(),
                    Street = dataTable.Rows[0].ItemArray[3].ToString()
                };
                return locationModel;
            }
        }

        internal static List<CarModel> GetCars()
        {
            List<CarModel> carModels = new List<CarModel>();
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM car", mySqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            carModels.Add(new CarModel()
                            {
                                Id = Convert.ToInt32(row.ItemArray[0]),
                                Name = row.ItemArray[1].ToString(),
                                Make = row.ItemArray[2].ToString(),
                                Power = Convert.ToInt32(row.ItemArray[3]),
                                Seats = Convert.ToInt32(row.ItemArray[4]),
                                Trunksize = Convert.ToInt32(row.ItemArray[5]),
                                CarClass = row.ItemArray[6].ToString(),
                                Gearbox = row.ItemArray[7].ToString(),
                                Fuel = row.ItemArray[8].ToString(),
                                Coupling = Convert.ToBoolean(row.ItemArray[9]),
                                Location = GetLocation(Convert.ToInt32(row.ItemArray[10]), mySqlConnection)
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    return carModels;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            return carModels;
        }
    }
}