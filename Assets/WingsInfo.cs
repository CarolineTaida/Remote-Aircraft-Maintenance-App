using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WingsInfo : MonoBehaviour
{
    public string maintenanceInfo = @"
    Wings Maintenance Information:

    1. Last Maintenance Date: 2025-01-10
    2. Maintenance Performed:
       - Visual inspection of wing structure
       - Lubrication of wing hinges and control surfaces
       - Replacement of worn-out wing components
       - Repainting of wing surfaces

    3. Next Scheduled Maintenance: 2025-07-10
    4. Maintenance Interval: Every 6 months or 1000 flight hours

    5. Maintenance Checklist:
       - Check for any cracks, dents, or deformations on wing surfaces
       - Inspect wing attachments and fasteners for security and integrity
       - Verify proper operation of wing control surfaces (ailerons, flaps, etc.)
       - Lubricate moving parts and hinges as per manufacturer's guidelines
       - Perform any necessary repairs or replacements
       - Update maintenance records and logbooks

    6. Additional Notes:
       - Pay special attention to the wing leading edges and wingtips during inspections
       - Ensure proper balancing and alignment of wing control surfaces
       - Follow all safety precautions and manufacturer's instructions during maintenance
       - Report any abnormalities or discrepancies to the maintenance supervisor
    ";

    private void OnEnable()
    {
        Debug.Log("Displaying information for the wings:");
        Debug.Log("Maintenance Info: " + maintenanceInfo);
        // Add your logic here to display the wings information in the app UI
    }
}
