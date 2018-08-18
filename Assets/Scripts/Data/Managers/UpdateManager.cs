using System.Collections.Generic;
using System.Linq;

public static class UpdateManager
{
    private static Dictionary<int, UpdateController> _updates;

    public static void Init(IEnumerable<UpdateModel> updates)
    {
        _updates = new Dictionary<int, UpdateController>();

        foreach (var update in updates)
        {
            _updates.Add(update.id, new UpdateController(update));
        }
    }

    public static IEnumerable<UpdateController> GetUpdates()
    {
        return _updates?.Values.AsEnumerable();
    }

    public static UpdateController GetUpdate(int id)
    {
        UpdateController update = null;
        _updates?.TryGetValue(id, out update);
        return update;
    }
}