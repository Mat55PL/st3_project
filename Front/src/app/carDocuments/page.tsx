'use client';
import React, { useEffect, useState } from 'react';
import { useRouter, usePathname, useSearchParams } from 'next/navigation'

interface Document {
    id: number;
    name: string;
    carId: number;
    startDate: string;
    endDate: string;
}

const CarDocuments: React.FC = () => {
    const router = useRouter();
    const params = useSearchParams();
    const query = router;

    const [carId, setCarId] = useState<number | null>(null);
    const [documents, setDocuments] = useState<Document[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    //const router = useRouter();
    //const { carId } = router.query;

    useEffect(() => {
        const carIdTest = Number(params.get('carId'));
        console.log('Car ID:', carIdTest);
        setCarId(carIdTest);
        console.log('setCar ID :', carId);

        if (!carIdTest) {
            setError('Car ID is not provided');
            setIsLoading(false);
            return;
        }

        fetch(`http://localhost:5210/api/Document/Car/${carIdTest}`)
            .then(response => {
                if (response.status === 404) {
                    setError('Nie znaleziono dokumentów dla podanego pojazdu');
                }
                return response.json();
            })
            .then(data => {
                // Sort documents from newest to oldest
                const sortedDocuments = data.sort((a: Document, b: Document) => new Date(b.endDate).getTime() - new Date(a.endDate).getTime());
                setDocuments(sortedDocuments);
                setIsLoading(false);
            })
            .catch(error => {
                console.error('Error fetching documents: ', error);
                setError(`Problem z pobraniem dokumentów`);
                setIsLoading(false);
            });
    }, [params]);

    if (isLoading) {
        return <div className="flex justify-center items-center min-h-screen">Trwa ładowanie danych...</div>;
    }

    const handleAddNewDocument = () => {
        router.push(`/addNewDocument?carId=${carId}`);
    };

    const handleBackToHome = () => {
        router.push('/');
    };

    if (error) {
        return (
            <div className="flex justify-center items-center min-h-screen">
                <div className="text-red-700 bg-white border border-red-400 rounded-lg px-4 py-3 shadow-sm max-w-md text-center">
                    <strong>Wystąpił błąd aplikacji:</strong> {error}
                    <br />
                    <button
                        onClick={handleBackToHome}
                        className='rounded-full bg-blue-500 text-white p-3 shadow-lg hover:bg-blue-600 transition duration-300 hover:shadow-xl'
                        aria-label="Powrót do strony głównej"
                    >
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512" fill="currentColor" className="w-6 h-6">
                            <path d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4 .1-2.8 .1-4.2 .1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2 .1-2.4 .2-3.6 .2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z" />
                        </svg>
                    </button>
                </div>
            </div>
        );
    }



    return (
        <div className="min-h-screen flex flex-col items-center justify-center p-5 bg-gray-800">
            <h1 className="text-2xl font-bold text-center mb-6">Dokumenty pojazdu</h1>
            <div className="absolute top-5 right-5 flex space-x-4">
                <button
                    onClick={handleAddNewDocument}
                    className='rounded-full bg-green-500 text-white p-3 shadow-lg hover:bg-green-600 transition duration-300'
                    aria-label="Dodaj nowy pojazd"
                >
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2} className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
                    </svg>
                </button>
                <button
                    onClick={handleBackToHome}
                    className='rounded-full bg-blue-500 text-white p-3 shadow-lg hover:bg-blue-600 transition duration-300 hover:shadow-xl'
                    aria-label="Powrót do strony głównej"
                >
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512" fill="currentColor" className="w-6 h-6">
                        <path d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4 .1-2.8 .1-4.2 .1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2 .1-2.4 .2-3.6 .2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z" />
                    </svg>
                </button>
            </div>
            <div className="grid grid-cols-1 gap-4">
                {documents.map(doc => {
                    const isExpired = new Date(doc.endDate) < new Date();
                    return (
                        <div key={doc.id} className="border rounded-lg p-4 shadow-lg bg-gray-600">
                            <h2 className={`text-xl font-semibold ${isExpired ? 'text-red-500' : 'text-gray-200'}`}>{doc.name}</h2>
                            <p>Data rozpoczęcia: {new Date(doc.startDate).toLocaleDateString()}</p>
                            <p>Data zakończenia: {new Date(doc.endDate).toLocaleDateString()}</p>
                        </div>
                    );
                })}
            </div>
        </div>
    );
};

export default CarDocuments;