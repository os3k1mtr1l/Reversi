namespace Reversi
{
    public partial class Window : Form
    {
        private readonly GameController m_controller;

        public Window()
        {
            InitializeComponent();

            m_controller = new GameController(
                turn_indendification,
                score_text,
                play_zone
            );

            m_controller.Restart();
        }

        private void OnRestart_Click(object sender, EventArgs e)
        {
            m_controller.Restart();
        }

        private void OnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            if(settings.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"Mode set: {Settings.GetMode()}\nDifficulty: {Settings.GetDifficulty()}");
                m_controller.Restart();
            }
        }
    }
}