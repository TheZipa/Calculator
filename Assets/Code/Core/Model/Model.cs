using Core.Data.Enums;

namespace Core.Model
{
    public abstract class Model
    {
        public WindowId Id { get; }

        protected Model(WindowId id) => Id = id;
    }
}