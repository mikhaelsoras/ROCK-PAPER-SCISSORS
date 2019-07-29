using ROCK_PAPER_SCISSOR.Business;
using System;
using System.Windows;

namespace ROCK_PAPER_SCISSORS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void BtnStartTournamentClick(object sender, RoutedEventArgs e)
        {
            StartTournament();
        }

        private void StartTournament()
        {
            try
            {
                Game game = new Game();
                var winner = game.rps_game_winner(tbInput.Text);
                MessageBox.Show($"Winner: {winner[0]}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
    }
}
