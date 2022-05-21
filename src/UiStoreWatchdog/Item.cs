using System.ComponentModel.DataAnnotations;

namespace UiStoreWatchdog
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string name, string url, bool active)
        {
            Name = name;
            Url = url;
            NotificationsActive = active;
        }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Url { get; set; }

        [Display(Name = "Notify me")]
        public bool NotificationsActive { get; set; }
    }
}
