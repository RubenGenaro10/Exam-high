using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace practica_final_examen.API.Personnel.Domain.Model.Aggregates;

public partial class Examiner : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedDate")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedDate")]
    public DateTimeOffset? UpdatedDate { get; set; }
   
}