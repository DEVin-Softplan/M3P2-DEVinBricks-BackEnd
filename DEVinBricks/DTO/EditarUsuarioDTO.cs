namespace DEVinBricks.DTO
{
    public class EditarUsuarioDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public bool? Admin { get; set; }
        public bool? Ativo { get; set; }
    }
}
