using PIS.Models;
using Npgsql;
using System.Collections.Generic;
using PIS.Models.Enums;
using System;
using System.Threading.Tasks;

namespace PIS.Services
{
    public class DatabaseService
    {
        private readonly string connectionString;
        private readonly PasswordHasher _passwordHasher;

        public DatabaseService(string connectionString, PasswordHasher passwordHasher)
        {
            this.connectionString = connectionString;
            _passwordHasher = passwordHasher;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM users";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString(),
                            Role = (UserRole)Enum.Parse(typeof(UserRole), reader["role"].ToString()),
                            Online = (bool)reader["online"],
                            LastActivity = DateTime.Parse(reader["last_activity"].ToString()),
                            CreatedAt = DateTime.Parse(reader["created_at"].ToString())
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public List<UserApplication> GetAllApplications()
        {
            var applications = new List<UserApplication>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM applications";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var application = new UserApplication
                        {
                            Id = (int)reader["id"],
                            OwnerEmail = reader["email"].ToString(),
                            OwnerName = reader["name"].ToString(),
                            OwnerPassport = reader["passport"].ToString(),
                            Address = reader["address"].ToString(),
                            MigrantName = reader["migrant_name"].ToString(),
                            MigrantPassport = reader["migrant_passport"].ToString(),
                            VisaNumber = reader["visa_number"].ToString(),
                            MigrationCard = reader["migration_card"].ToString(),
                            Status = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), reader["status"].ToString())
                        };

                        applications.Add(application);
                    }
                }
            }

            return applications;
        }

        public void AddUser(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO users (name, email, password, role)
            VALUES (@name, @email, @password, @role)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", _passwordHasher.HashPassword(user.Password));
                    command.Parameters.AddWithValue("@role", user.Role.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM users WHERE id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ChangeUserRole(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE users SET role = @role WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role", user.Role.ToString());
                    command.Parameters.AddWithValue("@id", user.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void SetUserOnlineStatus(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "UPDATE users SET online = @online WHERE id = @userId",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@online", user.Online);
                    cmd.Parameters.AddWithValue("@userId", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLastActivity(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "UPDATE users SET last_activity = NOW() WHERE id = @userId",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@userId", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

