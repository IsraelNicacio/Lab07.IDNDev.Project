using IDN.Core.DomainObject;

namespace IDN.Core.Data;

public interface IRepository<T> : IDisposable where T : EntityBase;
