namespace RestAPIWithApsNet8.Data.Converter.Contract
{
    public interface IParser<O, D> //(O = origem e D = Desino)
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);

       // O Parse(D ogigin);
        //List<O> Parse(List<D> origin);
    }
}
