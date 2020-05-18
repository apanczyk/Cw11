using System.Collections.Generic;

namespace Cw11.Models
{
    public class Medicament
    {
        public Medicament()
        {
            PrescriptionsMedicaments = new HashSet<PrescriptionMedicament>();
        }
        
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        
        public virtual ICollection<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }
    }
}