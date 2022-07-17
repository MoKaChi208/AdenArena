
public class Account
{
    public string username {  get; private set; }
    private string password { get; set; }
    public string clientname { get; private set; }
    public string email { get; private set; }


    public Account() { }
    public Account(string clientname, string email, string username, string password)
    {
        this.clientname = clientname;
        this.email = email;
        this.username = username;
        this.password = password;
    }

    public Account(string username)
    {
        this.username = username;
    }
}
