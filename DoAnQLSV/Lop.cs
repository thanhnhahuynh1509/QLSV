
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DoAnQLSV
{

using System;
    using System.Collections.Generic;
    
public partial class Lop
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Lop()
    {

        this.SinhViens = new HashSet<SinhVien>();

    }


    public int maLop { get; set; }

    public string tenLop { get; set; }

    public string monHoc { get; set; }

    public string buoi { get; set; }

    public string mau { get; set; }

    public Nullable<int> maTaiKhoan { get; set; }



    public virtual TaiKhoan TaiKhoan { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SinhVien> SinhViens { get; set; }

}

}
