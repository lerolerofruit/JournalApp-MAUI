using JournalApp_MAUI.Models;

namespace JournalApp_MAUI.ViewModels;

public class EntryViewModel
{
    public Mood SelectedPrimaryMood { get; set; }
    public List<Mood> SelectedSecondaryMoods { get; set; } = new();

    public void ValidateMoods()
    {
        if (SelectedPrimaryMood == null)
            throw new Exception("Primary mood is required.");

        if (SelectedSecondaryMoods.Count > 2)
            throw new Exception("Only two secondary moods allowed.");
    }
}
