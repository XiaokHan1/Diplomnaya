//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreatureMonster.Helpers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Authorization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Authorization()
        {
            this.Creature = new HashSet<Creature>();
        }
    
        public int Id { get; set; }
        public string FCs { get; set; }
        public string Nikname { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creature> Creature { get; set; }
    }
}
