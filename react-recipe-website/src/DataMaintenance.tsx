
import { useState } from 'react';
import DataMaintenaceSidebar from './DataMaintenaceSidebar'
import DataMaintenanceGrid from './DataMaintenanceGrid'
export default function DataMaintenance() {

    const [selectedTableOption, setSelectedTableOption] = useState("users");

    const handleTableOptionSelected = (tableOption: string) => {
        setSelectedTableOption(tableOption);
    }

    const handleTableChange = () => {

    };
    
    return (<>
        <div>Data Maintenance</div>
        <div className='row'>
            <div className="col-4">
                <DataMaintenaceSidebar onOptionSelected={handleTableOptionSelected} />
            </div>
            <div className="col-8">
                <DataMaintenanceGrid tableOption={selectedTableOption} onChanged={handleTableChange}/>
            </div>
        </div>

    </>
    )
}
