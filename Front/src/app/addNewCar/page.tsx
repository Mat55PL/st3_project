'use client';
import React, { useState } from 'react';
import { useRouter } from 'next/navigation'
interface Car {
    brand: string;
    model: string;
    year: number;
    fuelType: number; // 0: Gasoline, 1: Diesel, 2: Electric, 3: Hybrid
    wheelType: number; // 0: Summer, 1: Winter, 2: AllSeason
    numberPlate: string;
}

const AddNewCar: React.FC = () => {
    var router = useRouter();
    const [car, setCar] = useState<Car>({
        brand: '',
        model: '',
        year: new Date().getFullYear(),
        fuelType: 0,
        wheelType: 0,
        numberPlate: ''
    });

    const HandleBackToHome = () => {
        // move to the home page
        router.push('/');
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setCar({ ...car, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        console.log('Submitting new car:', car);
        // Here you would typically handle the POST request to your API to add the car
    };

    return (
        <div className='max-w-4xl mx-auto p-5'>
            <h1 className='text-2xl font-bold text-center mb-6'>Dodaj nowy pojazd</h1>
            <button
                onClick={HandleBackToHome}
                className='absolute right-5 top-5 rounded-full bg-green-500 text-white p-3 shadow-lg hover:bg-green-600 transition duration-300 hover:shadow-xl'
                aria-label="Powrót do strony głównej"
            >
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512" fill="currentColor" className="w-6 h-6">
                    <path d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4 .1-2.8 .1-4.2 .1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2 .1-2.4 .2-3.6 .2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z" />
                </svg>
            </button>
            <form onSubmit={handleSubmit} className='bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4'>
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="brand">
                    Marka
                </label>
                <input
                    type="text"
                    name="brand"
                    value={car.brand}
                    onChange={handleChange}
                    className='shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline'
                    id="brand"
                    required
                />
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="model">
                    Model
                </label>
                <input
                    type="text"
                    name="model"
                    value={car.model}
                    onChange={handleChange}
                    className='shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline'
                    id="model"
                    required
                />
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="year">
                    Rok produkcji
                </label>
                <input
                    type="number"
                    name="year"
                    value={car.year}
                    onChange={handleChange}
                    className='shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline'
                    id="year"
                    required
                />
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="fuelType">
                    Typ paliwa
                </label>
                <select
                    name="fuelType"
                    value={car.fuelType}
                    onChange={handleChange}
                    className='block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline'
                    id="fuelType"
                    required
                >
                    <option value="0">Benzyna</option>
                    <option value="1">Diesel</option>
                    <option value="2">Elektryczny</option>
                    <option value="3">Hybrydowy</option>
                </select>
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="wheelType">
                    Typ opon
                </label>
                <select
                    name="wheelType"
                    value={car.wheelType}
                    onChange={handleChange}
                    className='block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline'
                    id="wheelType"
                    required
                >
                    <option value="0">Letnie</option>
                    <option value="1">Zimowe</option>
                    <option value="2">Całoroczne</option>
                </select>
                <label className='block text-gray-700 text-sm font-bold mb-2' htmlFor="numberPlate">
                    Numer rejestracyjny
                </label>
                <input
                    type="text"
                    name="numberPlate"
                    value={car.numberPlate}
                    onChange={handleChange}
                    className='shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline'
                    id="numberPlate"
                    required
                />
                <button type="submit" className='bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline mt-4'>
                    Dodaj pojazd
                </button>
            </form>
        </div>
    );
};

export default AddNewCar;
