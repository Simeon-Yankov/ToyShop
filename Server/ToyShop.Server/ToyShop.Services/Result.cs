namespace ToyShop.Services
{
    public class Result
    {
        public bool Succeeded { get; init; }

        public bool Failure => !Succeeded;

        public string Error { get; init; }

        public static implicit operator Result(bool succeeded)
            => new Result { Succeeded = succeeded };

        public static implicit operator Result(string error)
            => new Result 
            {
                Succeeded = false,
                Error = error 
            };
    }
}