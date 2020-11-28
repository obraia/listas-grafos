namespace grafo
{
    public class Aresta
    {
        public static int IdCount = 1;
        public int Id { get; private set; }
        public Professor Professor { get; private set; }
        public Aresta(Professor professor)
        {
            this.Id = IdCount;
            this.Professor = professor;
        }

        public override string ToString()
        {
            return this.Professor.Nome + " : " + this.Professor.Disciplina;
        }
    }
}
