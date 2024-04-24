using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Sources;
using UnityEngine;

public class StaffDataSource : MonoBehaviour, IWorkerDataSource
{

    // HR
    [SerializeField] int SrHrQuantity; 
    [SerializeField] int SsrHrQuantity; 
    [SerializeField] int JrHrQuantity; 
    
    // Engineers
    [SerializeField] int SrEngineersQuantity; 
    [SerializeField] int SsrEngineersQuantity; 
    [SerializeField] int JrEngineersQuantity; 
    
    // Artists
    [SerializeField] int SrArtistsQuantity; 
    [SerializeField] int SsrArtistsQuantity;
    
    // Designers
    [SerializeField] int SrDesignersQuantity; 
    [SerializeField] int JrDesignersQuantity;
    
    // Designers
    [SerializeField] int SrPmsQuantity; 
    [SerializeField] int SsrPmsQuantity;

    private IEnumerable<Worker> _staffWorkers = new List<Worker>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        var hrWorkers = CreateWorkers(quantity: SrHrQuantity, position: Position.HR, seniority: Seniority.Senior)
            .Concat(CreateWorkers(quantity: SsrHrQuantity, position: Position.HR, seniority: Seniority.SemiSenior))
            .Concat(CreateWorkers(quantity: JrHrQuantity, position: Position.HR, seniority: Seniority.Junior));

        var engineersWorkers = CreateWorkers(quantity: SrEngineersQuantity, position: Position.Engineering, seniority: Seniority.Senior)
            .Concat(CreateWorkers(quantity: SsrEngineersQuantity, position: Position.Engineering, seniority: Seniority.SemiSenior))
            .Concat(CreateWorkers(quantity: JrEngineersQuantity, position: Position.Engineering, seniority: Seniority.Junior));
        
        var artistsWorkers = CreateWorkers(quantity: SrArtistsQuantity, position: Position.Artist, seniority: Seniority.Senior)
            .Concat(CreateWorkers(quantity: SsrArtistsQuantity, position: Position.Artist, seniority: Seniority.SemiSenior));
        
        var designersWorkers = CreateWorkers(quantity: SrDesignersQuantity, position: Position.Design, seniority: Seniority.Senior)
            .Concat(CreateWorkers(quantity: JrDesignersQuantity, position: Position.Design, seniority: Seniority.Junior));
        
        var pmsWorkers = CreateWorkers(quantity: SrPmsQuantity, position: Position.PM, seniority: Seniority.Senior)
            .Concat(CreateWorkers(quantity: SsrPmsQuantity, position: Position.PM, seniority: Seniority.SemiSenior));

        _staffWorkers = hrWorkers.Concat(engineersWorkers)
            .Concat(artistsWorkers)
            .Concat(designersWorkers)
            .Concat(pmsWorkers)
            .Concat(new Worker[] { new("Ceo", "Ceo", Position.CEO, Seniority.Senior) });

    }
    public IEnumerable<Worker> FetchWorkers() => _staffWorkers;

    private IEnumerable<Worker> CreateWorkers(int quantity, Position position, Seniority seniority) => 
        Enumerable.Range(0, quantity).ToList().ConvertAll(i => new Worker(firstName: i.ToString(), lastName: i.ToString(), position: position, seniority: seniority));
}
