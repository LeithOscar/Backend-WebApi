
namespace Api.LogicalBussines
{
    using Api.LogicalBussines.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product<T> where T : IBook
    {
        private List<T> dataModel;

        public Product(List<T> data)
        {
            this.dataModel = data;
        }

        public List<T> Offset(int offset, int count)
        {

            bool success = Int64.TryParse(offset.ToString(), out long id);
            var take = count > this.dataModel.Count() ? this.dataModel.Count() : count;

            if (success)
            {
                //should be a repo to get data
                return this.dataModel.OrderBy(pr => pr.Id)
                                    .Where(x => x.Id != id)
                                    .Take(take)
                                    .ToList();
            }
            return null;

        }

        public T GetById(long id)
        {
            //should be a repo to get data
            return this.dataModel.FirstOrDefault(x => x.Id == id);

        }

        public List<T> GetAll()
        {
            //should be a repo to get data
            return this.dataModel;

        }

        public void Add(T item)
        {

            if (item == null)
            {
                //should be a repo to get data
                var has = this.dataModel.FirstOrDefault(x => x.Id == item.Id);

                if (has!= null) { return; }
            }
        }

        public void Update(T item)
        {
            if (item != null)
            {
                //should be a repo to get data
                var has = this.dataModel.FirstOrDefault(x => x.Id == item.Id);

                if (has== null) { return; }

                has = item;
            }
        }

        public void Delete(long id)
        {
            //should be a repo to get data
            var exist = this.dataModel.FirstOrDefault(x => x.Id == id);

            if (exist== null) { return; }

            this.dataModel.Remove(exist);

        }


    }
}
