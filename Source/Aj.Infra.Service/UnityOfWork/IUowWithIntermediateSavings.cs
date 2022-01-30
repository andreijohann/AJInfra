using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aj.Infra.Service.UnityOfWork
{
    /// <summary>
    /// Unit of Work interface with possibility of intermediate saves.
    /// </summary>
    public interface IUowWithIntermediateSavings: IUow
    {
        /// <summary>
        /// Saves the changes made so far.
        /// </summary>
        void Save();
    }
}
