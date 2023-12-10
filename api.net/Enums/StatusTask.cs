using System.ComponentModel;

namespace api.net.Enums
{
    public enum StatusTask
    {
        [Description("A fazer")]
        Occupation = 1,
        [Description ("Em Andamento")]
        InProgress = 2,
        [Description("Concluido")]
        Concluded = 3
    }
}
