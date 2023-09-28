using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class Warehouse : Entity<Identifier>, IAggregateRoot
    {
        [Required]
    public WarehouseId WarehouseIdentifier { get; private set; }
     
    [Required]

    public WarehouseDesignation Designation { get;  private set; } 
    
    public Coordinate Coordinates { get; private  set; }

    public Address Address { get;  private set; }

    public Altitude WarehouseAltitude { get; private set; }

    public bool Active{ get;  set; }


    private Warehouse()
    {         
        this.Active = true;

    }

    public Warehouse(WarehouseId warehouseIdentifier,WarehouseDesignation designation, Coordinate coordinates, Address address, Altitude warehouseAltitude)
    {
        Id = new Identifier(Guid.NewGuid());
        this.WarehouseIdentifier = warehouseIdentifier;
        this.Designation = designation;
        this.Coordinates = coordinates;
        this.Address = address;
        this.WarehouseAltitude = warehouseAltitude;
        this.Active = true;
    }



    public void ChangeDesignation(WarehouseDesignation designation)
    {
        if(!this.Active)
            throw new Exception("It's not possible to change the designation of an inactive Warehouse!");
        this.Designation = designation;
    }

    public void ChangeAddress(Address address)
    {
        if(!this.Active)
            throw new Exception("It's not possible to change the address of an inactive Warehouse!");
        this.Address = address;
    }

    public void ChangeCoordinates(Coordinate coordinates)
    {
        if(!this.Active)
            throw new Exception("It's not possible to change the coordinates of an inactive Warehouse!");
        this.Coordinates = coordinates;
    }

    public void ChangeAltitude(Altitude warehouseAltitude)
    {
        if(!this.Active)
            throw new Exception("It's not possible to change the altitude of an inactive Warehouse!");
        this.WarehouseAltitude = warehouseAltitude;
    }

    public void MarkAsInative()
    {
        this.Active = false;
    }
    
    public void MarkAsActive()
    {
        this.Active = true;
        
    }
    }

}