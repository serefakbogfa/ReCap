using Business.Abstract;
using Business.Constans;
using Core.DataAccess.Utilities.Results.Abstracts;
using Core.DataAccess.Utilities.Results.Concrete;
using DataAccess.Abstracts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.brandAddedMessage);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal?.Delete(brand);
            return new SuccessResult(Messages.brandDeletedMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 17) //eğer saat 17 ise sistem bakımda error mesajı verir,değilse success olur
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.brandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.brandGetById);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.brandUpdatedMessage);
        }
    }
}
