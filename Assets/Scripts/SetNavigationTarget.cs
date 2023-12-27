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
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-033"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-035"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-036"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-037"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-038"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-039"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-040"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-041"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-042"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-043"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-044"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-045/045А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-046"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-048/048А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-050/050А"));
        }

        if (floorNumber == 1)
        { 
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Радиоточка"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Столовая"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Женский туалет 1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-101"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-102"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-103"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-104"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-105"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-106"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-107"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-108"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-109"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-110"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-111"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-112"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-113"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-114"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-116"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-118"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-121"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-122"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-123"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-124"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-125"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-126"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-127"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-127А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-127Т"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-128"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-129"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-129Б"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-129В"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-130"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-132"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-134"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-135"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-136"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-137"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-138"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-138А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-139"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-140"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-141"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-142"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-143"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-144"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-145"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-146"));
        }

        if (floorNumber == 2)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Мужской туалет 2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Женский туалет 2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-201"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-202"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-203"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-204"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-205/207"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-206"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-208"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-209"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-210"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-211"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-212"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-213"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-214"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-215"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-216/218"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-217"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-219"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-219А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-222"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-223"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-224"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-225"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-226"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-227"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-229"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-230"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-231"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-232"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-233"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-234"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-235"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-236"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-237"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-239"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-240"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-241"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-242"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-243"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-244"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-245"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-246"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-247"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-248"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-250"));
        }

        if (floorNumber == 3)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Мужской туалет 3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Женский туалет 3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-301"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-302"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-303"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-303A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-304"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-305"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-306"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-308"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-309A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-309Б"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-311"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-313"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-313"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-314"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-314А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-315"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-316/318"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-317"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-319"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-320"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-321"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-322"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-323"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-324"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-325"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-326"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-327"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-328"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-329"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-330"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-331"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-332"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-333"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-334"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-335"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-336"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-337"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-338"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-339"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-340"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-340А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-341"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-341А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-342"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-342А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-343"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-344"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-345"));
        }

        if (floorNumber == 4)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Мужской туалет 4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Женский туалет 4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-401"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-402"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-402А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-403"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-404"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-405"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-406"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-407"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-408/408А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-409"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-410"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-411"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-412"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-413"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-414"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-415"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-416"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-417"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-418"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-418А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-419"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-420"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-421"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-422"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-423"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-424"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-425"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-426"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-426А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-427"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-427А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-428"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-429"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-430"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-431"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-432"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-433"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-434"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-435"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-435А"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-436"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-437"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-438"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-439"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-440"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-441"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-442"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-443"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Р-445"));
        }
    }
} 
