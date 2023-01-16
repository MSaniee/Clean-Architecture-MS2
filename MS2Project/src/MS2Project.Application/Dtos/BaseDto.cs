﻿using AutoMapper;
using MS2Project.Application.Mapping;
using MS2Project.Domain.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace MS2Project.Application.Dtos;

public abstract class BaseDto<TDto, TEntity, TKey> : IHaveCustomMapping
       where TDto : class, new()
       where TEntity : BaseEntity<TKey>, new()
{
    [Display(Name = "ردیف")]
    public TKey Id { get; set; }

    public TEntity ToEntity(IMapper mapper)
    {
        return mapper.Map<TEntity>(CastToDerivedClass(mapper, this));
    }

    public TEntity ToEntity(IMapper mapper, TEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    public TDto ToDto(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    protected TDto CastToDerivedClass(IMapper mapper, BaseDto<TDto, TEntity, TKey> baseInstance)
    {
        return mapper.Map<TDto>(baseInstance);
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }
}

public abstract class BaseDto<TDto, TEntity> : BaseDto<TDto, TEntity, int>
    where TDto : class, new()
    where TEntity : BaseEntity<int>, new()
{
}

public abstract class BaseIEntityDto<TDto, TEntity, TKey> : IHaveCustomMapping
    where TDto : class, new()
    where TEntity : IEntity
{
    [Display(Name = "ردیف")]
    public TKey Id { get; set; }

    public TEntity ToEntity(IMapper mapper)
    {
        return mapper.Map<TEntity>(CastToDerivedClass(mapper, this));
    }

    public TEntity ToEntity(IMapper mapper, TEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    protected TDto CastToDerivedClass(IMapper mapper, BaseIEntityDto<TDto, TEntity, TKey> baseInstance)
    {
        return mapper.Map<TDto>(baseInstance);
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression);
        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }

    public virtual void CustomMappings(IMappingExpression<TDto, TEntity> mapping)
    {
    }
}

public abstract class BaseMessageEntityDto<TDto, TEntity> : IHaveCustomMapping
where TDto : class, new()
where TEntity : class, IEntity
{


    public TEntity ToEntity(IMapper mapper)
    {
        return mapper.Map<TEntity>(CastToDerivedClass(mapper, this));
    }

    public TEntity ToEntity(IMapper mapper, TEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    protected TDto CastToDerivedClass(IMapper mapper, BaseMessageEntityDto<TDto, TEntity> baseInstance)
    {
        return mapper.Map<TDto>(baseInstance);
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression);
        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }

    public virtual void CustomMappings(IMappingExpression<TDto, TEntity> mapping)
    {
    }
}

public abstract class BaseMessageEntityDto<TDto, TEntity, TMongoEntity> : IHaveCustomMapping
    where TDto : class, new()
    where TEntity : class, IEntity
    where TMongoEntity : class
{


    public TEntity ToEntity(IMapper mapper)
    {
        return mapper.Map<TEntity>(CastToDerivedClass(mapper, this));
    }

    public TEntity ToEntity(IMapper mapper, TEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    protected TDto CastToDerivedClass(IMapper mapper, BaseMessageEntityDto<TDto, TEntity, TMongoEntity> baseInstance)
    {
        return mapper.Map<TDto>(baseInstance);
    }

    //
    public TMongoEntity ToMongoEntity(IMapper mapper)
    {
        return mapper.Map<TMongoEntity>(CastToDerivedClass(mapper, this));
    }

    public TMongoEntity ToMongoEntity(IMapper mapper, TMongoEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TMongoEntity model)
    {
        return mapper.Map<TDto>(model);
    }



    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression);
        CustomMappings(mappingExpression.ReverseMap());


        var mongoMappingExpression = profile.CreateMap<TDto, TMongoEntity>();

        var mongoEntityType = typeof(TMongoEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in mongoEntityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mongoMappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mongoMappingExpression);
        CustomMappings(mongoMappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }

    public virtual void CustomMappings(IMappingExpression<TDto, TEntity> mapping)
    {
    }

    public virtual void CustomMappings(IMappingExpression<TMongoEntity, TDto> mapping)
    {
    }

    public virtual void CustomMappings(IMappingExpression<TDto, TMongoEntity> mapping)
    {
    }
}

