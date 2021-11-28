
namespace Api.LogicalBussines
{
    using Api.LogicalBussines.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product<T> where T : IProduct
    {
        private List<T> DataModel;

        public Product(List<T> data)
        {
            this.DataModel = data;
        }

        public List<T> Offset(int offset, int count)
        {

            bool success = Int64.TryParse(offset.ToString(), out long id);
            var take = count > this.DataModel.Count() ? this.DataModel.Count() : count;

            if (success)
            {
                //should be a repo to get data
                return this.DataModel.OrderBy(pr => pr.Id)
                                    .Where(x => x.Id != id)
                                    .Take(take)
                                    .ToList();
            }
            return null;

        }

        public T GetById(long id)
        {
            //should be a repo to get data
            return this.DataModel.FirstOrDefault(x => x.Id == id);

        }

        public List<T> GetAll()
        {
            //should be a repo to get data
            return this.DataModel;

        }

        public void Add(T item)
        {

            if (item == null)
            {
                //should be a repo to get data
                var has = this.DataModel.FirstOrDefault(x => x.Id == item.Id);

                if (has!= null) { return; }
            }
        }

        public void Update(T item)
        {
            if (item != null)
            {
                //should be a repo to get data
                var has = this.DataModel.FirstOrDefault(x => x.Id == item.Id);

                if (has== null) { return; }

                has = item;
            }
        }

        public void Delete(long id)
        {
            //should be a repo to get data
            var exist = this.DataModel.FirstOrDefault(x => x.Id == id);

            if (exist== null) { return; }

            this.DataModel.Remove(exist);

        }


    }
}
