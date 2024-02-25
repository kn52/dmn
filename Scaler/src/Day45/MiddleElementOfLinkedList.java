package Day45;

public class MiddleElementOfLinkedList {

	public static void main(String[] args) {
		int[] array = new int[] {  1, 2, 3, 4, 5 };
		ListNode head = new ListNode(array[0]);
		var temp = head;
		for (int i = 1; i < array.length; i++) {
			ListNode new_node = new ListNode(array[i]);
			temp.next = new_node;
			if ( i == 1) { 
				head.next = temp;
			}
			temp = temp.next;
		}
		int ans = solve(head);
		System.out.print(ans);
	}
	public static int solve(ListNode A) {
        ListNode slow = A;
        ListNode fast = A;
        int count = 1;
        while (fast != null && fast.next != null) {
            if (fast.next.next == null) {
                count += 1;
            }
            else {
                count += 2;
                slow = slow.next;
            }
            fast = fast.next.next;
        }
        if (count%2 == 0) {
            return slow.next.val;    
        }
        return slow.val;
    }
}
