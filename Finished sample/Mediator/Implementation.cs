namespace Mediator;

//public abstract class ChatRoom
//{
//    public abstract void Register(TeamMember teamMember);
//    public abstract void Send(string from, string message);
//}

/// <summary>
/// Mediator
/// </summary>
public interface IChatRoom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);
    void Send(string from, string to, string message);
    void SendTo<T>(string from, string message) where T : TeamMember;


}

/// <summary>
/// Colleague
/// </summary>
public abstract class TeamMember(string name)
{
    private IChatRoom? _chatroom;
    public string Name { get; set; } = name;

    internal void SetChatroom(IChatRoom chatRoom)
    {
        _chatroom = chatRoom;
    }
    public void Send(string to, string message)
    {
        _chatroom?.Send(Name, to, message);
    }

    public void SendTo<T>(string message) where T : TeamMember
    {
        _chatroom?.SendTo<T>(Name, message);
    }

    public void Send(string message)
    {
        _chatroom?.Send(Name, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"Message {from} to {Name}: {message}");
    }
}

/// <summary>
/// ConcreteColleague
/// </summary>
public class Lawyer(string name) : TeamMember(name)
{
    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
        base.Receive(from, message);
    }
}

/// <summary>
/// ConcreteColleague
/// </summary>
public class AccountManager(string name) : TeamMember(name)
{
    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
        base.Receive(from, message);
    }
}


/// <summary>
/// ConcreteMediator
/// </summary>
public class TeamChatRoom : IChatRoom
{
    private readonly Dictionary<string, TeamMember> _teamMembers = [];

    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatroom(this);
        if (!_teamMembers.ContainsKey(teamMember.Name))
        {
            _teamMembers.Add(teamMember.Name, teamMember);
        }
    }

    public void Send(string from, string message)
    {
        foreach (var teamMember in _teamMembers.Values)
        {
            teamMember.Receive(from, message);
        }
    }

    public void Send(string from, string to, string message)
    {
        var teamMember = _teamMembers[to];
        teamMember?.Receive(from, message);
    }

    public void SendTo<T>(string from, string message) where T : TeamMember
    {
        foreach (var teamMember in _teamMembers.Values.OfType<T>())
        {
            teamMember.Receive(from, message);
        }
    }
}
