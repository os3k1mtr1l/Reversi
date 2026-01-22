namespace Reversi
{
    public partial class Settings : Form
    {
        private static Mode m_mode = Mode.PVP;
        private static Difficulty m_difficulty = Difficulty.STANDARD;
        private readonly RadioButton[] m_difficulty_buttons;

        public Settings()
        {
            InitializeComponent();

            m_difficulty_buttons = [
                difficulty_radio_1,
                difficulty_radio_2,
                difficulty_radio_3,
            ];

            for (int i = 0; i < 3; i++)
            {
                m_difficulty_buttons[i].Checked = false;
            }

            m_difficulty_buttons[(int)m_difficulty].Checked = true;

            radio_switch_true.Checked = m_mode == Mode.PVE;
            radio_switch_false.Checked = m_mode == Mode.PVP;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            m_mode = radio_switch_true.Checked? Mode.PVE : Mode.PVP;

            for(int i = 0; i < m_difficulty_buttons.Length; i++)
            {
                m_difficulty = m_difficulty_buttons[i].Checked ? (Difficulty)i : m_difficulty;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public static Mode GetMode()
        {
            return m_mode;
        }

        public static Difficulty GetDifficulty()
        {
            return m_difficulty;
        }

        private void radio_switch_true_CheckedChanged(object sender, EventArgs e)
        {
            difficulty_group.Enabled = true;
        }

        private void radio_switch_false_CheckedChanged(object sender, EventArgs e)
        {
            difficulty_group.Enabled = false;
        }
    }
}