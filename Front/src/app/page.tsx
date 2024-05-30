'use client';
import Image from "next/image";
import React, { useEffect, useState } from "react";
import { useRouter } from 'next/navigation'
interface Car {
  id: number;
  brand: string;
  model: string;
  year: number;
  fuelType: number; // 0: Gas, 1: Diesel, 2: Electric
  wheelType: number; // 0: Standard, 1: Sport, 2: Off-road
  numberPlate: string;
}



export default function Home() {
  const router = useRouter();

  const [cars, setCars] = useState<Car[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  useEffect(() => {
    fetch('http://localhost:5132/api/Car')
      .then(response => response.json())
      .then(data => {
        setCars(data)
        setIsLoading(false)
      })
      .catch(error => {
        console.error('Error fetching data: ', error);
        setError('Error fetching data');
        setIsLoading(false);
      });
  }, []);

  const handleAddNewCar = () => {
    // move to the add new car page
    router.push('/addNewCar');
  };

  const handleCarDocuments = (carId: number) => {
    // move to the car documents page
    router.push(`/carDocuments?carId=${carId}`);
  };

  if (isLoading) {
    return <div className="flex justify-center items-center min-h-screen">
      Trwa ładowanie danych...
    </div>;
  }

  if (error) {
    return (
      <div className="flex justify-center items-center min-h-screen">
        <div className="bg-orange-300 border border-red-400 text-red-700 px-4 py-3 rounded relative max-w-md mx-auto">
          <strong className="font-bold">🛑 Wystąpił błąd aplikacji: </strong>
          <span className="block sm:inline">{error.toString()}</span>
        </div>
      </div>
    );
  }


  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <div className='p-5'>
        <h1 className='text-2xl font-bold text-center mb-4'>Twoje pojazdy</h1>
        <button
          onClick={handleAddNewCar}
          className='absolute right-5 top-5 rounded-full bg-green-500 text-white p-3 shadow-lg hover:bg-green-600 transition duration-300'
          aria-label="Dodaj nowy pojazd"
        >
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2} className="w-6 h-6">
            <path strokeLinecap="round" strokeLinejoin="round" d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
          </svg>
        </button>
        <div className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4'>
          {cars.map(car => (
            <div key={car.id} className='border rounded-lg p-4 shadow-lg bg-gray-600'>
              <h2 className='text-xl font-semibold'>{car.brand} {car.model}</h2>
              <p>Rok: {car.year}</p>
              <p>Typ paliwa: {car.fuelType === 0 ? 'Benzyna' : car.fuelType === 1 ? 'Diesel' : car.fuelType === 2 ? 'Elektryczny' : 'Hybryda'}</p>
              <p>Typ kół: {car.wheelType === 0 ? 'Letnie ☀️' : car.wheelType === 1 ? 'Zimowe ❄️' : 'AllSeason ⛅'}</p>
              <p>Numer rejestracyjny: {car.numberPlate}</p>
              <br />
              <p className="flex gap-2">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded transition duration-300 ease-in-out focus:outline-none focus:shadow-outline" onClick={() => handleCarDocuments(car.id)}>
                  Dokumenty 📝
                </button>
                <button className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded transition duration-300 ease-in-out focus:outline-none focus:shadow-outline">
                  Przeglądy 🛠️
                </button>
              </p>
            </div>
          ))}
        </div>
      </div>
    </main>
  );
}
