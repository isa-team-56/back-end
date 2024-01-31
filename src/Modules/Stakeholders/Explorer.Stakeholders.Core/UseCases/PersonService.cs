using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class PersonService : CrudService<PersonDto, Person>, IPersonService
    {
        public PersonService(ICrudRepository<Person> repository, IMapper mapper) : base(repository, mapper) { }

        public Result<PersonDto> GetPersonByUserId(int id)
        {
            //Trying to get all users
            Result<PagedResult<PersonDto>> allUsers = GetPaged(1, int.MaxValue);

            //Cheking if there is any user
            if (allUsers.IsSuccess)
            {
                var userProfiles = allUsers.Value.Results;

                //Finding user by given id
                var userProfile = userProfiles.FirstOrDefault(user => user.UserId == id);

                if (userProfile != null)
                {
                    return Result.Ok(userProfile);
                }
            }

            return Result.Fail<PersonDto>(FailureCode.NotFound);

        }
        

        public Result<PersonDto> changePenaltyPoints(int id,int quantity)
        {
            var person = GetPersonByUserId(id);
            var personDb = CrudRepository.Get(person.Value.Id);

            if (personDb != null)
            {

                personDb.PenaltyPoints += quantity;


                CrudRepository.Update(personDb);


                return MapToDto(personDb);
            }
            else
            {

                return Result.Fail<PersonDto>("Person not found.");
            }
        }
    }
}
