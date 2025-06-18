using System;
using System.ComponentModel.DataAnnotations;

namespace Sekure.Models;

public abstract class Audit
{
    public int User { get; set; }
    public DateTime CreationDate { get; set; }
    [Timestamp]
    public byte[] ModifiedDate { get; set; }
}