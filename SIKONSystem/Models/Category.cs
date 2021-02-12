using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Category
    {
        //Her er endnu en tilfældig kommentar, som kan slettes.
        public int CategoryId { get; set; }

        private string _name;
        [Required]
        [Display(Name = "Kategori")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Navigation Properties

        public ICollection<Lecture> Lectures { get; set; }

        public Category()
        {
            
        }

        public Category(string name)
        {
            _name = name;
        }
    }
}
