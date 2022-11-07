using AutoMapper;
using PrismMauiApp.Interface;
using PrismMauiApp.Model;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp.Service
{
    class WordService : IService<Word>
    {
        private UnitOfWork uow;
        IMapper mapper;


        public WordService(UnitOfWork uow)
        {
            this.uow = uow;
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                .CreateMap<WordDB, Word>()
                .ReverseMap();
            });
            mapper = config.CreateMapper();
        }


        public Task<bool> UpdateRange(IEnumerable<Word> dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<IEnumerable<WordDB>>(dto);
                    uow.WordsRepository.UpdateRange(entity);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });

        }

        public Task<Word> Create(Word dto)
        {
            try
            {
                return Task.Run(() =>
                {

                    var entity = mapper.Map<WordDB>(dto);
                    var newEntity = uow.WordsRepository.Create(entity);
                    return mapper.Map<Word>(newEntity);

                });
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public Task<bool> Delete(Word dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = uow.WordsRepository.Get(dto.Id);
                    uow.WordsRepository.Delete(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }

        public Task<Word> Get(int id)
        {
            try
            {
                return Task.Run(() =>
                {
                    var entity = uow.WordsRepository.Get(id);
                    return mapper.Map<Word>(entity);
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<IEnumerable<Word>> GetAll()
        {
            try
            {
                return Task.Run(() =>
                {
                    var res = uow.WordsRepository
                    .GetAll()
                    .ToList()
                    .Select(entity => mapper.Map<Word>(entity));
                    return res;
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> Save()
        {

            return Task.Run(() =>
            {
                try
                {
                    uow.WordsRepository.Save();
                    uow.Save();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }

            });

        }

        public Task<bool> Update(Word dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<WordDB>(dto);
                    uow.WordsRepository.Update(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }
    }
}
