using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObject = new List<Target>();
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    private int currentFloor = 1;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObject.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null)
        {
            if (!line.enabled)
            {
                ToggleVisibility();
            }
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }

    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber)
    {
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private Vector3[] AddLineOffset()
    {
        if (navigationYOffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }
        return calculatedLine;
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber)
    {
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if(line.enabled)
        {
            ToggleVisibility();
        }

        if (floorNumber == 0)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-033"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-035"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-036"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-037"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-038"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-039"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-040"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-041"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-042"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-043"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-044"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-045/045�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-046"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-048/048�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-050/050�"));
        }

        if (floorNumber == 1)
        { 
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("����������"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("��������"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-101"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-102"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-103"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-104"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-105"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-106"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-107"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-108"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-109"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-110"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-111"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-112"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-113"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-114"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-116"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-118"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-121"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-122"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-123"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-124"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-125"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-126"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-127"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-127�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-127�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-128"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-129"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-129�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-129�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-130"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-132"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-134"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-135"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-136"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-137"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-138"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-138�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-139"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-140"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-141"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-142"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-143"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-144"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-145"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-146"));
        }

        if (floorNumber == 2)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-201"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-202"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-203"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-204"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-205/207"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-206"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-208"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-209"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-210"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-211"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-212"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-213"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-214"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-215"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-216/218"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-217"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-219"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-219�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-222"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-223"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-224"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-225"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-226"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-227"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-229"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-230"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-231"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-232"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-233"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-234"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-235"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-236"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-237"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-239"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-240"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-241"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-242"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-243"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-244"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-245"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-246"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-247"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-248"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-250"));
        }

        if (floorNumber == 3)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-301"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-302"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-303"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-303A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-304"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-305"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-306"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-308"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-309A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-309�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-311"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-313"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-313"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-314"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-314�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-315"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-316/318"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-317"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-319"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-320"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-321"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-322"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-323"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-324"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-325"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-326"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-327"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-328"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-329"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-330"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-331"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-332"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-333"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-334"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-335"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-336"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-337"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-338"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-339"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-340"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-340�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-341"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-341�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-342"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-342�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-343"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-344"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-345"));
        }

        if (floorNumber == 4)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("������� ������ 4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-401"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-402"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-402�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-403"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-404"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-405"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-406"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-407"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-408/408�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-409"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-410"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-411"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-412"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-413"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-414"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-415"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-416"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-417"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-418"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-418�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-419"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-420"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-421"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-422"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-423"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-424"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-425"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-426"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-426�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-427"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-427�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-428"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-429"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-430"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-431"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-432"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-433"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-434"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-435"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-435�"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-436"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-437"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-438"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-439"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-440"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-441"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-442"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-443"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("�-445"));
        }
    }
} 
