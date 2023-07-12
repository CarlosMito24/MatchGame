using Microsoft.Maui.Controls;

namespace MatchGame;

/// <summary>
/// Se inicia la app, el metodo SetUpGame() y el timer para contar el tiempo
/// </summary>
public partial class MainPage : ContentPage
{
    public MainPage()
	{        
        InitializeComponent();

        SetUpGame();

        IDispatcherTimer timer;
        timer = Dispatcher.CreateTimer();
        int count = 0;
        Temporizador.Text = "0:00";
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            count += 1;
            TimeSpan time = TimeSpan.FromSeconds(count);
            Temporizador.Text = time.ToString(@"m\:ss");
        };
        timer.Start();
    }

    /// <summary>
    /// Se declar el metodo SetUpGame, y lo que lleva, como la lista de los emojis que irán en los botones 
    /// </summary>
    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
        {
            "🐶","🐶",
            "🙈","🙈",
            "🦑","🦑",
            "🐘","🐘",
            "🦓","🦓",
            "🦒","🦒",
            "🐍","🐍",
            "🐬","🐬",
        };
        Random random = new Random();
        foreach (Button view in Grid1.Children)
        {
            int index = random.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            view.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }
    }

    /// <summary>
    /// Se declaran metodos y las acciones que ocurriran al momento de presionar los botones/Emojis
    /// </summary>
    Button ultimoButtonClicked;
    bool encontrandoMatch = false;
    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (encontrandoMatch == false)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontrandoMatch = true;
        }

        else if (button.Text == ultimoButtonClicked.Text)
        {
            button.IsVisible = false;
            encontrandoMatch = false;
        }
        else
        {
            ultimoButtonClicked.IsVisible = true;
            encontrandoMatch = false;
        }
    }

    /// <summary>
    /// Metodo en el boton Reiniciar para reiniciar todo el juego 
    /// </summary>
    private void ReiniciarClicked (object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}