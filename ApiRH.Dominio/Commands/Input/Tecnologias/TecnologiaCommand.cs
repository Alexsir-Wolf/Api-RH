using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Tecnologias;

public class TecnologiaCommand : Notifiable<Notification>
{
    public string? Nome { get; set; }
    public string? Peso { get; set; }

    public new bool IsValid()
    {
        if (Nome == null)
            AddNotification("Nome", "Nome é obrigatório!");     
        
        if (Peso == null)
            AddNotification("Peso", "Peso é obrigatório!");

        return Notifications.Count <= 0;
    }
}
