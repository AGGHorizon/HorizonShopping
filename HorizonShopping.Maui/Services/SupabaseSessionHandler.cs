using Newtonsoft.Json;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace HorizonShopping.Maui.Services
{
public class SupabaseSessionHandler : IGotrueSessionPersistence<Session>
{
    private const string SessionKey = "supabase_session";

    //GUARDADO SESIÓN
    public void SaveSession(Session session)
    {
        string json = JsonConvert.SerializeObject(session);

        Preferences.Set(SessionKey, json);
    }

    //CARGA SESIÓN
    public Session? LoadSession()
    {
        string? json = Preferences.Get(SessionKey, null);

        if (string.IsNullOrWhiteSpace(json))
            return null;

        try
        {
            Session? session = JsonConvert.DeserializeObject<Session>(json);

            return session;
        }
        catch
        {
            return null;
        }
    }

    //ELIMINACIÓN SESIÓN
    public void DestroySession()
    {
        Preferences.Remove(SessionKey);
    }
}
}