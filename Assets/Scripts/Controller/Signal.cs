using EgdFoundation;

public class UpdateFieldOfViewCamera : Signal
{
}

public class UpdatePlayerScore : Signal
{
    public int score;

    public UpdatePlayerScore(int score)
    {
        this.score = score;
    }
}

public class TimeOutSignal : Signal
{
}