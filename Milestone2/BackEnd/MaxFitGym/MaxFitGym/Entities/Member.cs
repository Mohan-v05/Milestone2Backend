﻿namespace MaxFitGym.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public List<Program> programs{ get; set; }
        public string MembershipType {  get; set; }
        public DateTime JoinDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
