﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data;

namespace Carsharing
{
    public class Controller
    {
        public List<CarModel> CarModels = new List<CarModel>();
        public UserModel UserModel;
        
        public Controller()
        {

        }

        #region Insert
        public bool InsertLocation(string postcode, string city, string street)
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
                    return true;
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

        public bool InsertCar(string name, string make, int power, int seats, int trunksize, string carClass, string gearbox, string fuel, bool coupling, int location_id, DateTime reserved, DateTime blocked, string reservedBy, string blockedBy)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO car (name, make, power, seats, trunksize, class, gearbox, fuel, coupling, location_id, reserved, blocked, reservedby, blockedby) "
                        + "VALUES (@name, @make, @power, @seats, @trunksize, @class, @gearbox, @fuel, @coupling, @location_id, @reserved, @blocked, @reservedby, @blockedby)", mySqlConnection);
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
                    mySqlCommand.Parameters.AddWithValue("reserved", reserved.ToString("yyyy-MM-dd HH:mm:ss"));
                    mySqlCommand.Parameters.AddWithValue("blocked", blocked.ToString("yyyy-MM-dd HH:mm:ss"));
                    mySqlCommand.Parameters.AddWithValue("reservedby", reservedBy);
                    mySqlCommand.Parameters.AddWithValue("blockedby", blockedBy);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                    return true;
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

        public bool InsertUser(string username, string password, string email, string firstname, string lastname, string birthday, string iban, bool admin)
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
                    return true;
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
        #endregion

        #region Get
        public UserModel GetUser(string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    UserModel userModel = new UserModel();
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM user WHERE username = @username", mySqlConnection))
                    {
                        mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("username", username);
                        mySqlDataAdapter.SelectCommand.Prepare();
                        mySqlDataAdapter.Fill(dataTable);
                        userModel = new UserModel()
                        {
                            Username = dataTable.Rows[0].ItemArray[0].ToString(),
                            Password = dataTable.Rows[0].ItemArray[1].ToString(),
                            Admin = Convert.ToBoolean(dataTable.Rows[0].ItemArray[7])
                        };
                        return userModel;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        public LocationModel GetLocation(int id, MySqlConnection mySqlConnection)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM location WHERE id = @id", mySqlConnection))
                {
                    mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                    mySqlDataAdapter.SelectCommand.Prepare();
                    mySqlDataAdapter.Fill(dataTable);
                    return new LocationModel()
                    {
                        Id = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]),
                        Postcode = dataTable.Rows[0].ItemArray[1].ToString(),
                        City = dataTable.Rows[0].ItemArray[2].ToString(),
                        Street = dataTable.Rows[0].ItemArray[3].ToString()
                    };
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CarModel> GetCars()
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
                                Location = GetLocation(Convert.ToInt32(row.ItemArray[10]), mySqlConnection),
                                Reserved = Convert.ToDateTime(row.ItemArray[11]),
                                Blocked = Convert.ToDateTime(row.ItemArray[12]),
                                ReservedBy = row.ItemArray[13].ToString(),
                                BlockedBy = row.ItemArray[14].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            return carModels;
        }

        public int GetLocationId(string postcode, string city, string street)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT id FROM location WHERE postcode = @postcode AND " +
                        "city = @city AND street = @street", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("postcode", postcode);
                    mySqlCommand.Parameters.AddWithValue("city", city);
                    mySqlCommand.Parameters.AddWithValue("street", street);
                    mySqlCommand.Prepare();
                    return Convert.ToInt32(mySqlCommand.ExecuteScalar());
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }
        #endregion

        #region Update
        public bool UpdateCarReserved(int id, DateTime reserved, string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE car SET reserved = @reserved, reservedby = @reservedby " +
                        "WHERE id = @id", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("id", id);
                    mySqlCommand.Parameters.AddWithValue("reserved", reserved.ToString("yyyy-MM-dd HH:mm:ss"));
                    mySqlCommand.Parameters.AddWithValue("reservedby", username);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                    return true;
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

        public bool UpdateCarBlocked(int id, DateTime blocked, string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE car SET blocked = @blocked, blockedby = @blockedby " +
                        "WHERE id = @id", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("id", id);
                    mySqlCommand.Parameters.AddWithValue("blocked", blocked.ToString("yyyy-MM-dd HH:mm:ss"));
                    mySqlCommand.Parameters.AddWithValue("blockedby", username);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                    return true;
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

        public bool UpdateCar(int id, string name, string make, int power, int seats, int trunksize, string carClass, string gearbox, string fuel, bool coupling, int location_id)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE car SET name = @name, make = @make, power = @power, seats = @seats, trunksize = @trunksize, " +
                        "class = @class, gearbox = @gearbox, fuel = @fuel, coupling = @coupling, location_id = @location_id WHERE id = @id", mySqlConnection);
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
                    mySqlCommand.Parameters.AddWithValue("id", id);
                    mySqlCommand.Prepare();
                    mySqlCommand.ExecuteNonQuery();
                    return true;
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
        #endregion
    }
}