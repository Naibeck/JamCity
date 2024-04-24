using System;
using Data;
using Data.Sources;
using Presenters;
using SeviceLocator;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UseCases;

public class CalculateModule : MonoBehaviour
{
    public GameObject salaryDataSource;
    public GameObject staffDataSource;

    void Awake()
    {
        // Repositories
        ServiceLocator.For(this).Register<ISalaryRepository>(new SalaryRecordRepositoryImpl(dataSource: salaryDataSource.GetComponent<ISalaryRecordDataSource>()));
        ServiceLocator.For(this).Register<IWorkersRepository>(new WorkersRepositoryImpl(dataSource: staffDataSource.GetComponent<IWorkerDataSource>()));
        
        // UseCases
        ServiceLocator.For(this).Register(new CalculateHrAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        ServiceLocator.For(this).Register(new CalculateEngineersAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        ServiceLocator.For(this).Register(new CalculateArtistAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        ServiceLocator.For(this).Register(new CalculateDesignersAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        ServiceLocator.For(this).Register(new CalculatePmsAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        ServiceLocator.For(this).Register(new CalculateCeoAnnualIncrease(salaryRepository: ServiceLocator.For(this).Get<ISalaryRepository>()));
        
        // Presenter
        ServiceLocator.For(this).Register<ICalculatePresenter>(new CalculatePresenterImpl(
            repository: ServiceLocator.For(this).Get<IWorkersRepository>(),
            hrIncrease: ServiceLocator.For(this).Get<CalculateHrAnnualIncrease>(),
            engineersIncrease: ServiceLocator.For(this).Get<CalculateEngineersAnnualIncrease>(),
            artistIncrease: ServiceLocator.For(this).Get<CalculateArtistAnnualIncrease>(),
            designIncrease: ServiceLocator.For(this).Get<CalculateDesignersAnnualIncrease>(),
            pmsIncrease: ServiceLocator.For(this).Get<CalculatePmsAnnualIncrease>(),
            ceoIncrease: ServiceLocator.For(this).Get<CalculateCeoAnnualIncrease>()
        ));
    }
}
