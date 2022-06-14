using System;
using System.Collections.Generic;
using System.Linq;
using JsonHelper;

namespace MantisTester.Models
{
    public class IdName : IEquatable<IdName>
    {
        public IdName(long id, string value)
        {
            Id = id;
            Value = value;
        }
        public long Id { get; set; }
        public string Value { get; set; }

        public bool Equals(IdName other)
        {
            return Id == other.Id && Value == other.Value;
        }

        public override string ToString()
        {
            return this.ToJson();
        }
    }

    public class IdNameDictonary : List<IdName>
    {
        public string ValueById(long id)
        {
            var result = this.Where(x => x.Id == id).FirstOrDefault()?.Value;
            if (result == null) throw new Exception($"Не найден элемент с Id={id}");
            return result;
        }
        public long IdByValue(string value)
        {
            var result = this.Where(x => x.Value == value).FirstOrDefault()?.Id;
            if (result == null) throw new Exception($"Не найден элемент с Value={value}");
            return result.Value;
        }
        public void Add(long id, string value) => Add(new IdName(id, value));
    }
}
