
import { useState } from 'react';
import DataMaintenaceSidebar from './DataMaintenaceSidebar'
import DataMaintenanceGrid from './DataMaintenanceGrid'
export default function DataMaintenance() {

    const [selectedTableOption, setSelectedTableOption] = useState("users");
    const [refreshKey, setRefreshKey] = useState(0);

    const handleTableOptionSelected = (tableOption: string) => {
        setSelectedTableOption(tableOption);
    }

    const handleTableChange = () => {
        setRefreshKey(prevKey => prevKey + 1);
    };

    return (<>
        <div>Data Maintenance</div>
        <div className='row'>
            <div className="col-4">
                <DataMaintenaceSidebar onOptionSelected={handleTableOptionSelected} />
            </div>
            <div className="col-8">
                <DataMaintenanceGrid tableOption={selectedTableOption} onChanged={handleTableChange} key={refreshKey} />
            </div>
        </div>

    </>
    )
}
