using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace HDLNoCGen
{
    public class DatabaseManager
    {
        private SQLiteConnection SqliteConnection;

        private string _connectionString;

        public DatabaseManager(string connectionPath)
        {
            _connectionString = $"Data Source={connectionPath}";
            SqliteConnection = new SQLiteConnection(_connectionString);
            SqliteConnection.Open();
        }

        // there are 2 methods is an example for db form, 
        // where you will need an insertions while compiling
        public void insertDevice(int id, string device, string family,
            int total_logic, int total_reg, int total_pins, int total_memory,
            int total_multipliers, string frequency, string size, string power,
            int total_plls, int total_ufms, int total_adcs)
        {
            using (var connection = SqliteConnection.CreateCommand()) {
                connection.CommandText = "INSERT INTO hardware (id, device, family, total_logic, " +
                                         "total_reg, total_pins, total_mem, total_mult, frequency, " +
                                         "size, power, total_plls, total_ufms, total_adcs) VALUES " +
                                         "(@id, @device, @family, @total_logic, @total_reg, @total_pins, " +
                                         "@total_memory, @total_multipliers, @frequency, @size, @power, " +
                                         "@total_plls, @total_ufms, @total_adcs)";

                connection.Parameters.AddWithValue("@id", id);
                connection.Parameters.AddWithValue("@device", device);
                connection.Parameters.AddWithValue("@family", family);
                connection.Parameters.AddWithValue("@total_logic", total_logic);
                connection.Parameters.AddWithValue("@total_reg", total_reg);
                connection.Parameters.AddWithValue("@total_pins", total_pins);
                connection.Parameters.AddWithValue("@total_memory", total_memory);
                connection.Parameters.AddWithValue("@total_multipliers", total_multipliers);
                connection.Parameters.AddWithValue("@frequency", frequency);
                connection.Parameters.AddWithValue("@size", size);
                connection.Parameters.AddWithValue("@power", power);
                connection.Parameters.AddWithValue("@total_plls", total_plls);
                connection.Parameters.AddWithValue("@total_ufms", total_ufms);
                connection.Parameters.AddWithValue("@total_adcs", total_adcs);

                connection.ExecuteNonQuery();
            }
        }

        public void insertSimulation(int id, string configuration, string algorithm,
            string device, int logic_elements, int pins, int memory_bits, int mult_elements,
            int plls, int ufms, int adcs){
            using (var command = SqliteConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO simulations (id, configuration, algorithm, device, " + 
                    "logic_elements, pins, memory_bits, mult_elements, plls, ufms, adcs) VALUES " + 
                    "(@id, @configuration, @algorithm, @device, @logic_elements, @pins, @memory_bits, @mult_elements, " + 
                    "@plls, @ufms, @adcs)";

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@configuration", configuration);
                command.Parameters.AddWithValue("@algorithm", algorithm);
                command.Parameters.AddWithValue("@device", device);
                command.Parameters.AddWithValue("@logic_elements", logic_elements);
                command.Parameters.AddWithValue("@pins", pins);
                command.Parameters.AddWithValue("@memory_bits", memory_bits);
                command.Parameters.AddWithValue("@mult_elements", mult_elements);
                command.Parameters.AddWithValue("@plls", plls);
                command.Parameters.AddWithValue("@ufms", ufms);
                command.Parameters.AddWithValue("@adcs", adcs);

                command.ExecuteNonQuery();
            }
        }

        public void getAllDevices()
        {
            /* Will be implemented later */
        }

        public DataTable getAllSimulations()
        {
            using (var command = SqliteConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM simulations";
                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable; // makes possible import to the dataGridView
                }
            }
        }

        public void getCustomSimulationsQuery()
        {

        }

        
    }
}
