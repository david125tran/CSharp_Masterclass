using System;
using System.Collections.Generic;
using System.Configuration; // Add Connection String variable
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Section17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            /* To link the connection string, from "Solution Explorer", 
             * right click "References", "Add Reference...".  Add
             * "System.Configuration".  
             * 
             * Add the package:
             * using System.Configuration; 
             */
            string connectionString = ConfigurationManager.ConnectionStrings["Section17.Properties.Settings.CSharpDBTutorialConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            ShowZoos();
            ShowAllAnimals();
        }

        private void ShowZoos()
        {
            /// <summary>
            /// This function loads all zoos in the the all zoos listbox.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "SELECT * FROM Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // Make data table with list of zoos
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    // Fill content of listbox ("listZoos")
                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void ShowAssociatedAnimals()
        {
            /// <summary>
            /// This function loads all animals associated with a given
            /// zoo when a zoo is selected from the listbox.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "SELECT * FROM Animal a INNER JOIN ZooAnimal " +
                    "za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId;";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    // Pass the clicked "ZooId" into the SQL transaction
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    // Make data table with list of animals for that "ZooId"
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    // Fill content of listbox ("listAssociatedAnimals")
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void ShowAllAnimals()
        {
            /// <summary>
            /// This function shows all animals in the database.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "SELECT * FROM ANIMAL";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // Make data table with list of all animals 
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    // Fill content of listbox
                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                    listAllAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <summary>
            /// This function is for when the end user clicks on different
            /// zoos.
            /// </summary>

            ShowAssociatedAnimals();
            ShowSelectedZooInTextBox();

        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function is for when the end user deletes a zoo
            /// from the list of zoos.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "DELETE FROM ZOO WHERE id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);  
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
                
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowZoos();
            }
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function is for when a zoo is added to the list of zoos.
            /// </summary>
            try
            {                
                // SQL Transaction
                string query = "INSERT INTO Zoo VALUES (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowZoos();
            }
        }

        private void AddAnimaltoZoo_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function is for when the end user adds an animal to one
            /// of the zoos.
            /// </summary>
            
            try
            {                   
                // SQL Transaction
                string query = "INSERT INTO ZooAnimal VALUES (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowAssociatedAnimals();
            }
        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function removes an animal from the list of animals
            /// in a zoo when an animal is selected from a zoo.
            /// 
            /// This function is for the button that is the left most
            /// "Delete Animal" button.  
            /// </summary>
            
            try
            {              
                // SQL Transaction
                string query = "DELETE FROM ZooAnimal WHERE AnimalId = @AnimalId AND ZooId = (@ZooId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAssociatedAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowAssociatedAnimals();
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function deletes an animal from the list of all animals 
            /// when an animal is selected from the list of all animals.
            /// 
            /// This function is for the button that is the right most 
            /// "Delete Animal" button.  It will also remove the animal from
            /// any zoos that it is stored in. 
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "DELETE FROM Animal WHERE id = (@AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowAssociatedAnimals();
                ShowZoos();
            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// This function adds an animal to the list of all animals
            /// by making a read to what is typed into the textbox.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "INSERT INTO Animal VALUES (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowAllAnimals();
            }
        }
        private void ShowSelectedZooInTextBox()
        {
            /// <summary>
            /// This function updates the textbox with the name of the selected
            /// zoo (that is slected from the list of all zoos).
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "SELECT location FROM Zoo WHERE Id = (@ZooId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    // Pass the clicked "ZooId" into the SQL transaction
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    // Make data table with list of zoos
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    // Fill content of textbox
                    myTextBox.Text = zooTable.Rows[0]["Location"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void ShowSelectedAnimalInTextBox()
        {
            /// <summary>
            /// This function updates the textbox with the name of the selected
            /// animal (that is slected from the list of all animals).
            /// </summary>
            
            try
            {
                // SQL Transaction
                string query = "SELECT name FROM Animal WHERE Id = (@AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    // Pass the clicked "AnimalId" into the SQL transaction
                    sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                    // Make data table with list of animals 
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    // Fill content of textbox
                    myTextBox.Text = zooTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void UpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Functionality for when the end user updates a zoo's name.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "UPDATE Zoo SET Location = (@Location) WHERE Id = (@ZooId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowZoos();
            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Functionality for when the end user updates an animal's name.
            /// </summary>

            try
            {
                // SQL Transaction
                string query = "UPDATE Animal SET Name = (@Name) WHERE Id = (@AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            finally
            {
                // Always close the connection
                sqlConnection.Close();
                // Update content of listbox ("listZoos")
                ShowAllAnimals();
                ShowAssociatedAnimals();
            }
        }

        private void listAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <summary>
            /// Functionality for when the end user clicks on a different 
            /// animal with the list of all animals.
            /// 
            /// It will call on ShowSelectedAnimalInTextBox() and update
            /// the textbox with the name of the selected animal.
            /// </summary>
            
            ShowSelectedAnimalInTextBox();
        }
    }
}
