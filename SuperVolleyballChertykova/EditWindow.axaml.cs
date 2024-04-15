using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySql.Data.MySqlClient;
using SuperVolleyball.Entities;

namespace SuperVolleyballChertykova;

public partial class EditWindow : Window
{
    
    private Player _player;
    private Database _database = new Database();
    private ObservableCollection<Position> _positions = new ObservableCollection<Position>();
    private ObservableCollection<Team> _teams = new ObservableCollection<Team>();
    private ObservableCollection<Player> _players = new ObservableCollection<Player>();
    public EditWindow( Player player)
    {
        InitializeComponent();
        FillPositionCBox();
        FillTeamCBox();
        _player = player;
        if (_player != null)
        {
            NameTBox.Text = _player.PlayerSurname;
            PositionCBox.SelectedItem = _player.Position;
            WeightTBox.Text = _player.Weight.ToString();
            HeightTBox.Text = _player.Height.ToString();
            BirthdayPicker.SelectedDate = _player.Birthday;
            GameStartPicker.SelectedDate = _player.GameStart;
            TeamCBox.SelectedItem = _player.Team;
        }

    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            _database.OpenConnection();
            string sql =
                "update player set player_name=@name, position=@pos, weight=@weight, height=@height, birthday=@birth, game_start=@game, team=@team where player_id = @id";
            
            MySqlCommand command = new MySqlCommand(sql, _database.GetConnection());
            command.Parameters.AddWithValue("@id", _player.PlayerId);
            command.Parameters.AddWithValue("@name", NameTBox.Text);
            int selectedPosition = GetSelectedPositionId(PositionCBox.SelectedItem.ToString());
            command.Parameters.AddWithValue("@pos", selectedPosition);
            command.Parameters.AddWithValue("@weight", WeightTBox.Text);
            command.Parameters.AddWithValue("@height", HeightTBox.Text);
            command.Parameters.AddWithValue("@birth", BirthdayPicker.SelectedDate);
            command.Parameters.AddWithValue("@game", GameStartPicker.SelectedDate);
            int selectedTeam = GetSelectedTeamId(TeamCBox.SelectedItem.ToString());
            command.Parameters.AddWithValue("@team", selectedTeam);
            command.ExecuteNonQuery();
            var success = MessageBoxManager.GetMessageBoxStandard("Успешно", "Данные успешно сохранены", ButtonEnum.Ok);
            var result = success.ShowAsync();
        }
        catch (Exception exception)
        {
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Ошибка" + exception, ButtonEnum.Ok);
            var result = error.ShowAsync();
        }
    }

    private void FillPositionCBox()
    {
        try
        {
            _database.OpenConnection();
            string sql = "select position_name from position";
            MySqlCommand command = new MySqlCommand(sql, _database.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var currentPosition = new Position()
                {
                    PositionName = reader.GetString("position_name")
                };
                _positions.Add(currentPosition);
            }
            _database.CloseConnection();
            PositionCBox.ItemsSource = _positions;
        }
        catch (Exception e)
        {
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Ошибка" + e, ButtonEnum.Ok);
            var result = error.ShowAsync();
        }
    }

    private int GetSelectedPositionId(string name)
    {
        _database.OpenConnection();
        string sql = "select position_id from position where position_name = @name";
        MySqlCommand command = new MySqlCommand(sql, _database.GetConnection());
        command.Parameters.AddWithValue("@name", name);
        int id = Convert.ToInt32(command.ExecuteScalar());
        return id;
    }

    private void FillTeamCBox()
    {
        try
        {
            _database.OpenConnection();
            string sql = "select team_name from team";
            MySqlCommand command = new MySqlCommand(sql, _database.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var currentTeam = new Team()
                {
                    TeamName = reader.GetString("team_name")
                };
                _teams.Add(currentTeam);
            }
            _database.CloseConnection();
            TeamCBox.ItemsSource = _teams;
        }
        catch (Exception e)
        {
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Ошибка" + e, ButtonEnum.Ok);
            var result = error.ShowAsync();
        }
    }
    
    private int GetSelectedTeamId(string name)
    {
        _database.OpenConnection();
        string sql = "select team_id from team where team_name = @name";
        MySqlCommand command = new MySqlCommand(sql, _database.GetConnection());
        command.Parameters.AddWithValue("@name", name);
        int id = Convert.ToInt32(command.ExecuteScalar());
        return id;
    }

    private void BackBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}