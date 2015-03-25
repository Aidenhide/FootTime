using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class BuyingOffer
    {
        [Key]
        public int OfferId { get; set; }
        public Team From { get; set; }
        public Team To { get; set; }
        public Player Player { get; set; }
        public decimal Value { get; set; }
        public OfferDecision Status { get; set; }

        public enum OfferDecision { NotDecided = 0, Accepted, Rejected };

        public BuyingOffer() { }
    }
}