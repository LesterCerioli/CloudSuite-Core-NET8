using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CloudSuite.Domain.Models;


namespace CloudSuite.Domain.Contracts
{
    public interface IWidgetRepository
    {
        Task<Widget> GetByName(string name);

        Task<Widget> GetByCreationDate(DateTimeOffset creationDate);

        Task<Widget> GetByLatesUpdatedDate(string createUrl);

        Task<Widget> GetByEditUrl(string editUrl);

        Task<IEnumerable<Widget>> GetList();

        Task Add(Widget widget);

        void Update(Widget widget);

        void Remove(Widget widget);
    }
}