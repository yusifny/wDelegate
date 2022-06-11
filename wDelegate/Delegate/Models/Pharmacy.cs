using System;
using System.Collections.Generic;
using Delegate.Exceptions;

namespace Delegate.Models
{
    public class Pharmacy
    {
        public int MedicineLimit { get; set; }
        private List<Medicine> _medicines;

        private bool IsExistsMedicine(Predicate<Medicine> predicate)
        {
            Medicine medicine = _medicines.Find(predicate);
            if (medicine == null)
            {
                return false;
            }
            return true;
        }

        public void AddMedicine(Medicine medicine)
        {
            if (_medicines.Count < MedicineLimit)
            {
                _medicines.Add(medicine);
                return;
            }

            if (IsExistsMedicine(m => m == medicine))
            {
                throw new MedicineAlreadyExistsException("Product doesn't exist");
            }
            else
            {
                throw new CapacityLimitException("The limit is reached");
            }
        }

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicinesCopy = new List<Medicine>();
            medicinesCopy.AddRange(_medicines);
            _medicines.FindAll(m => m.IsDeleted == false);
            return medicinesCopy;
        }

        public List<Medicine> FilterEmployeesBySalary(double minPrice, double maxPrice)
        {
            return _medicines.FindAll(m => m.Price >= minPrice && m.Price <= maxPrice);
        }

        public Medicine GetMedicineById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("ID cannot be null");

            Medicine medicine = _medicines.Find(m => m.Id == id && m.IsDeleted == false);

            return medicine;
        }

        public void DeleteMedicineById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("ID cannot be null");
            }
            else
            {
                Medicine medicine = _medicines.Find(m => m.Id == id && m.IsDeleted == false);
                if (medicine == null)
                {
                    throw new NotFoundException("The product is not available.");
                }

                medicine.IsDeleted = true;
            }
        }

        public void EditMedicineEmail(int? id, string name)
        {
            if (id == null)
                throw new NullReferenceException("ID and Name fields cannot be null");

            Medicine medicine = _medicines.Find(m => m.Id == id && m.IsDeleted == false);
            if (medicine == null)
                throw new NotFoundException("Product doesn't exist");

            medicine.Name = name;
        }
    }
}